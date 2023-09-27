using G_Pigmy.App.LookUp.Transaction.Query;
using GLib.CQRS.Query.Abstractions;
using GLib.Common;
using G_Pigmy.App.LookUp.Transaction.Response;
using G_Pigmy.App.DataControl.Interfaces;
using AutoMapper;
using GLib.CQRS.Validation.Abstractions;

namespace G_Pigmy.App.LookUp.Transaction.Handler
{
    public class GetTransactionByAgentHandler : AbstractQueryHandler<TransactionQueryOnAgent, Response<IEnumerable<TransactionResponse>>>
    {
        private readonly ITransactionDataControl _dataControl;
        private readonly IMapper _mapper;

        public GetTransactionByAgentHandler(ITransactionDataControl dataControl, IMapper mapper, IValidator<TransactionQueryOnAgent> validator) : base(validator) 
        {
            _dataControl = dataControl;
            _mapper = mapper;
        }

        protected override async Task<Response<IEnumerable<TransactionResponse>>> InternalHandleAsync(TransactionQueryOnAgent query)
        {
            try
            {
                var transactions = await _dataControl.GetTransactionsByAgentAsync(query.AgentCode);                
                return new Response<IEnumerable<TransactionResponse>>
                {
                  Data = transactions.Select(x => _mapper.Map<TransactionResponse>(x))
                };                   
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
