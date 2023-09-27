using AutoMapper;
using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.LookUp.Transaction.Query;
using G_Pigmy.App.LookUp.Transaction.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using GLib.CQRS.Validation.Abstractions;

namespace G_Pigmy.App.LookUp.Transaction.Handler
{
    public class GetTransactionByCustomerHandler : AbstractQueryHandler<TransactionQueryOnCustomer, Response<IEnumerable<GetTransactionByCustomerResponse>>>
    {
        private readonly ITransactionDataControl _dataControl;
        private readonly IMapper _mapper;

        public GetTransactionByCustomerHandler(ITransactionDataControl dataControl, IMapper mapper, IValidator<TransactionQueryOnCustomer> validator) : base(validator)
        {
            _dataControl = dataControl;
            _mapper = mapper;
        }

        protected override async Task<Response<IEnumerable<GetTransactionByCustomerResponse>>> InternalHandleAsync(TransactionQueryOnCustomer query)
        {
            try
            {
                var transaction = await _dataControl.GetTransactionsCustomerAsync(query.CustomerId, query.StartDate, query.EndDate);
                return new Response<IEnumerable<GetTransactionByCustomerResponse>>
                {
                    Data = transaction.Select(x => _mapper.Map<GetTransactionByCustomerResponse>(x))
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
