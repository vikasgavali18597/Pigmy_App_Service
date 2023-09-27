using AutoMapper;
using G_Pigmy.App.DataControl.Helper.Constant;
using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.LookUp.Customer.Queries;
using G_Pigmy.App.LookUp.Customer.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using GLib.CQRS.Validation.Abstractions;

namespace G_Pigmy.App.LookUp.Customer.Handlers
{
    public class GetCustomersHandler : AbstractQueryHandler<GetCustomersQuery, Response<IEnumerable<GetCustomerResponse>>>
    {
        private readonly ICustomerDataControl _customerDataControl;
        private readonly IMapper _mapper;
        public GetCustomersHandler(ICustomerDataControl customerDataControl, IMapper mapper, IValidator<GetCustomersQuery> validator) : base(validator)
        {
            _customerDataControl = customerDataControl; 
            _mapper = mapper;
        }

        protected override async Task<Response<IEnumerable<GetCustomerResponse>>> InternalHandleAsync(GetCustomersQuery query)
        {
            var customers = await _customerDataControl.GetAllByAgentCodeAsync(query.AgentCode!);

            if (customers!.Count() < 1 || customers == null)
            {
                return new Response<IEnumerable<GetCustomerResponse>> { Success = false, ErrorMessage = ErrorMessage.CUSTOMERS_ARE_EMPTY };
            }

            return new Response<IEnumerable<GetCustomerResponse>>
            {
                Data = customers.Select(c => _mapper.Map<GetCustomerResponse>(c))
            };
        }
    }
}
