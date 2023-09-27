using AutoMapper;
using Azure.Data.Tables;
using G_Pigmy.App.DataControl.Helper.Constant;
using G_Pigmy.App.DataControl.Helper.CustomeException;
using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.Models;
using GLib.Common;
using GLib.Models.Azure.TableStorage;
using GLib.Repository.Azure.TableStorage.Interfaces;
using System.Runtime.InteropServices;
using db = G_Pigmy.App.DbModels;
using AR = Azure;

namespace G_Pigmy.App.DataControl.Implementations
{
    public class TransactionDateControl : ITransactionDataControl
    {
        private readonly IRepositoryFactory<TableServiceClient> _repositoryFactory;
        private readonly IRepository<db.Transaction> _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUtility _utility;
        public TransactionDateControl(IRepositoryFactory<TableServiceClient> repositoryFactory, IMapper mapper, IUtility utility)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;

            _transactionRepository = _repositoryFactory.GetRepository<IRepository<db.Transaction>>();
            _utility = utility;

        }

        public async Task<Response> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                var rowKey = GenerateRowKey();

                var response = await SaveTransaction(transaction, rowKey);
                return new Response
                {
                    Success = response.IsError,
                    ErrorMessage = response.ReasonPhrase
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAgentAsync(string agentCode)
        {
            try
            {
                //var partitionKey = _utility.CreatePartitionKey(PartitionKey.AGENT_PARTITION_INDEX, agentCode);
                //var rowKey = await _transactionRepository.GetAllAsync(x => x.PartitionKey == partitionKey);
                //var transactions = await _transactionRepository.GetAllAsync(x => x.RowKey == rowKey!.Collection!.FirstOrDefault()!.RowKey);

                //if (!transactions.Collection!.Any() || transactions.Equals(null))
                //{
                //    throw new NotFoundException(ErrorMessage.TRANSACTIONS_NOT_FOUND);
                //}


                var lst = new BaseModelCollection<db.Transaction>
                {
                    Collection = new List<db.Transaction>
                    {
                        //Data
                        new db.Transaction
                        {
                            PartitionKey ="Data",RowKey = new Guid("1454bd6d-1a8d-4371-9852-44036e58507d").ToString(),
                            AccountId = "123456",  ClosingBalance= 1545, Deposit = 5445, OpeningBalance = 445455
                        },

                        new db.Transaction
                        {
                            PartitionKey ="Data",RowKey = new Guid("aab156c3-8a7d-4c4e-ab35-fadc8db6668d").ToString(),
                            AccountId = "123454",  ClosingBalance= 1545, Deposit = 5445, OpeningBalance = 445455
                        },

                        new db.Transaction
                        {
                            PartitionKey ="Data",RowKey = new Guid("c22733aa-b272-4a9d-ac13-b22b027a6abd").ToString(),
                            AccountId = "123457",  ClosingBalance= 1545, Deposit = 5445, OpeningBalance = 445455
                        },

                        //Agent
                        new db.Transaction
                        {
                            PartitionKey ="Agent_Code:1168",RowKey = new Guid("1454bd6d-1a8d-4371-9852-44036e58507d").ToString(),
                            AccountId = null!,  ClosingBalance= 0, Deposit = 0, OpeningBalance = 0
                        },

                        new db.Transaction
                        {
                            PartitionKey ="Agent_Code:1168",RowKey = new Guid("aab156c3-8a7d-4c4e-ab35-fadc8db6668d").ToString(),
                            AccountId = "123454",  ClosingBalance= 1545, Deposit = 5445, OpeningBalance = 445455
                        },

                        new db.Transaction
                        {

                            PartitionKey ="Agent_Code:1167",RowKey = new Guid("c22733aa-b272-4a9d-ac13-b22b027a6abd").ToString(),
                            AccountId = null!,  ClosingBalance= 0, Deposit = 0, OpeningBalance = 0
                        },
                         
                        //Customer
                        new db.Transaction
                        {
                            PartitionKey ="Customer_AccNo:123456",RowKey = new Guid("1454bd6d-1a8d-4371-9852-44036e58507d").ToString(),
                            AccountId = null!,  ClosingBalance= 0, Deposit = 0, OpeningBalance = 0
                        },

                        new db.Transaction
                        {
                            PartitionKey ="Customer_AccNo:123454",RowKey = new Guid("aab156c3-8a7d-4c4e-ab35-fadc8db6668d").ToString(),
                            AccountId = "123454",  ClosingBalance= 1545, Deposit = 5445, OpeningBalance = 445455
                        },

                        new db.Transaction
                        {
                            PartitionKey ="Customer_AccNo:123457",RowKey = new Guid("c22733aa-b272-4a9d-ac13-b22b027a6abd").ToString(),
                            AccountId = null!,  ClosingBalance= 0, Deposit = 0, OpeningBalance = 0
                        },
                    }
                };

                var partitionKey = _utility.CreatePartitionKey(PartitionKey.AGENT_PARTITION_INDEX, agentCode);

                var rowKeys = lst.Collection.Where(x => x.PartitionKey == partitionKey);

                var selected = new List<db.Transaction>();
                foreach (var key in rowKeys)
                {
                    var t = lst.Collection.Where(x => x.RowKey == key.RowKey && x.PartitionKey == "Data").FirstOrDefault();
                    selected.Add(t!);
                }

                return selected!.Select(x => _mapper.Map<Transaction>(x));

                //return transactions.Collection!.Select(x => _mapper.Map<Transaction>(x));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDate(string code, string date)
        {
            var partitionKey = _utility.CreatePartitionKey(PartitionKey.AGENT_PARTITION_INDEX, code);
            var rowKeys = await _transactionRepository.GetAllAsync(x => x.PartitionKey == partitionKey && x.Timestamp == new DateTimeOffset(Convert.ToDateTime(date)));

            var transactionList = new List<Transaction>();

            foreach (var key in rowKeys.Collection!)
            {
                var value = _mapper.Map<Transaction>(await _transactionRepository.GetByIdAsync(key.RowKey!));
                transactionList.Add(value);
            }

            return transactionList; ;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsCustomerAsync(string accountId, string startDate, string endDate)
        {
            try
            {
                var partitionKey = _utility.CreatePartitionKey(PartitionKey.CUSTOMER_PARTITION_INDEX, accountId);
                var rowKeys = await _transactionRepository.GetAllAsync(x => x.PartitionKey == partitionKey);


                var transactions = await _transactionRepository.GetAllAsync(x => x.Timestamp >= new DateTimeOffset(Convert.ToDateTime(startDate))
                && x.TimeStamp <= new DateTimeOffset(Convert.ToDateTime(endDate)) && x.RowKey == rowKeys!.Collection!.FirstOrDefault()!.RowKey);

                if (!transactions.Collection!.Any() || transactions.Equals(null))
                {
                    throw new NotFoundException(ErrorMessage.TRANSACTIONS_NOT_FOUND);
                }

                return transactions.Collection!.Select(x => _mapper.Map<Transaction>(x));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Private Method

        /// <summary>
        /// Generating RowKey using Guid 
        /// </summary>
        /// <returns>Guid as RowKey for TableStorage </returns>
        private string GenerateRowKey()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// This method save transaction with three different partition keys 
        /// like (agent_partition key, customer_partitionKey, and default partitionKey Data ) 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="rowKey"></param>
        /// <returns>It return azure response with isError or not </returns>
        private async Task<AR.Response> SaveTransaction(Transaction transaction, string rowKey)
        {
            try
            {

                var response0 = await _transactionRepository.AddEntityAsync(new db.Transaction
                {
                    PartitionKey = "Data",
                    RowKey = rowKey,
                    AccountId = transaction.AccountId,
                    OpeningBalance = transaction.OpeningBalance,
                    ClosingBalance = transaction.ClosingBalance,
                    Deposit = transaction.Deposit,
                });

                if (response0.IsError == true)
                {
                    return response0;

                }

                var response1 = await _transactionRepository.AddEntityAsync(ToDbTransactionForCustomer(transaction, rowKey));

                if (response1.IsError == true)
                {
                    return response1;
                }

                var response2 = await _transactionRepository.AddEntityAsync(ToDbTransactionForAgent(transaction, rowKey));

                return response2;

            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Creating object for storing transaction with agent partition key
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="rowKey"></param>
        /// <returns>Database Model Transaction</returns>
        private db.Transaction ToDbTransactionForAgent(Transaction transaction, string rowKey)
        {
            return new db.Transaction
            {
                PartitionKey = _utility.CreatePartitionKey(PartitionKey.AGENT_PARTITION_INDEX, transaction.AgentCode!),
                RowKey = rowKey,
            };
        }


        /// <summary>
        /// Creating object for storing transaction with Customer partition key
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="rowKey"></param>
        /// <returns>Database Model Transaction</returns>
        private db.Transaction ToDbTransactionForCustomer(Transaction transaction, string rowKey)
        {
            return new db.Transaction
            {
                PartitionKey = _utility.CreatePartitionKey(PartitionKey.CUSTOMER_PARTITION_INDEX, transaction.AccountId!),
                RowKey = rowKey,
            };
        }
        #endregion
    }
}
