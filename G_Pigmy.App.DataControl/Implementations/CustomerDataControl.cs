using Azure.Data.Tables;
using G_Pigmy.App.Models;
using Db = G_Pigmy.App.DbModels;
using GLib.Repository.Azure.TableStorage.Interfaces;
using AutoMapper;
using G_Pigmy.App.DataControl.Helper.CustomeException;
using G_Pigmy.App.DataControl.Helper.Constant;
using G_Pigmy.App.DataControl.Interfaces;
using System.Security.Cryptography.X509Certificates;
using G_Pigmy.App.DataControl.Helper.Extensions;

namespace G_Pigmy.App.DataControl.Implementations
{
    public class CustomerDataControl : ICustomerDataControl
    {
        private readonly IRepositoryFactory<TableServiceClient> _factory;
        private readonly IRepository<Db.Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUtility _utility;

        public CustomerDataControl(IRepositoryFactory<TableServiceClient> factory, IMapper mapper, IUtility utility)
        {
            _factory = factory;
            _customerRepository = _factory.GetRepository<IRepository<Db.Customer>>();
            _mapper = mapper;

            _utility = utility;
        }

        public async Task<IEnumerable<Customer>> GetAllByAgentCodeAsync(string agentCode)
        {
            try
            {
                var partitionKey = _utility.CreatePartitionKey(PartitionKey.AGENT_PARTITION_KEY, agentCode);
                var rowKeys = await _customerRepository.GetAllAsync(x => x.PartitionKey == partitionKey);

                var customers = new List<Customer>();
                foreach (var row in rowKeys.Collection!)
                {
                    var customer = await _customerRepository.GetByIdAsync(row.RowKey!);
                    customers.Add(customer.Value.ToCustomer());
                }
                return customers;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Customer> GetByCustomerAccountId(string accountId)
        {
            try
            {
                var partitionKey = _utility.CreatePartitionKey(PartitionKey.CUSTOMER_ACCOUNTID_PARTITION_INDEX, accountId);
                var rowKeys = await _customerRepository.GetAllAsync(x => x.PartitionKey == partitionKey);
                var rowKey = rowKeys.Collection!.FirstOrDefault()!.RowKey;

                return _mapper.Map<Customer>(await _customerRepository.GetByIdAsync(rowKey!));  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Customer> GetById(string partitionKey)
        {
            try
            {
                var rk = await _customerRepository.GetByIdAsync("" + partitionKey);

                if (rk.Value.RowKey == null)
                {
                    throw new NotFoundException(ErrorMessage.CUSTOMER_NOT_FOUND);
                }

                var customer = await _customerRepository.GetByIdAsync(rk.Value.RowKey);


                if (customer.Value == null)
                {
                    throw new NotFoundException(ErrorMessage.CUSTOMER_NOT_FOUND);
                }

                return _mapper.Map<Customer>(customer);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
