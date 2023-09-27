using AutoMapper;
using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.LookUp.Transaction.Query;
using G_Pigmy.App.LookUp.Transaction.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using GLib.CQRS.Validation.Abstractions;

namespace G_Pigmy.App.LookUp.Transaction.Handler
{
    public class GetTransactionByDateHandler : AbstractQueryHandler<GetTransactionQueryOnDate, Response<IEnumerable<GetTransactionResponse>>>
    {
        private readonly ITransactionDataControl _dataControl;
        private readonly IMapper _mapper;
        public GetTransactionByDateHandler(ITransactionDataControl dataControl, IMapper mapper, IValidator<GetTransactionQueryOnDate> validator) : base(validator)
        {
            _dataControl = dataControl;
            _mapper = mapper;
        }

        protected override async Task<Response<IEnumerable<GetTransactionResponse>>> InternalHandleAsync(GetTransactionQueryOnDate query)
        {
            try
            {
                var response = await _dataControl.GetTransactionsByDate(query.AgentCode!, query.Date!);
                return new Response<IEnumerable<GetTransactionResponse>>
                {
                    Data = _mapper.Map<IEnumerable<GetTransactionResponse>>(response)
                };
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
