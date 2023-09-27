using AutoMapper;
using Azure.Data.Tables;
using G_Pigmy.App.DataControl.Helper.Constant;
using G_Pigmy.App.DataControl.Helper.CustomeException;
using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.Models;
using GLib.Repository.Azure.TableStorage.Interfaces;
using System.Reflection.Metadata;
using db = G_Pigmy.App.DbModels;


namespace G_Pigmy.App.DataControl.Implementations
{
    internal class AgentDataControl : IAgentDataControl
    {
        private readonly IRepositoryFactory<TableServiceClient> _factory;
        private readonly IRepository<db.Agent> _agentRepository;
        private readonly IMapper _mapper;
        private readonly IUtility _utility;
        public AgentDataControl(IRepositoryFactory<TableServiceClient> factory, IMapper mapper, IUtility utility)
        {
            _factory = factory;
            _mapper = mapper;
            _agentRepository = _factory.GetRepository<IRepository<db.Agent>>();
            _utility = utility;
        }


        public async Task<Agent> GetAgentByIdAsync(string agentCode)
        {
            try
            {
                var partitionKey = _utility.CreatePartitionKey(PartitionKey.AGENT_PARTITION_INDEX, agentCode);
                var rowKeys = await _agentRepository.GetAllAsync(partitionKey);

                var agent = await _agentRepository.GetByIdAsync(rowKeys!.Collection!.FirstOrDefault()!.RowKey!)!;
                if (agent.Value == null)
                {
                    throw new NotFoundException(ErrorMessage.AGENT_NOT_FOUND);
                }

                return _mapper.Map<Agent>(agent.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
