using AutoMapper;
using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.LookUp.Customer.Queries;
using G_Pigmy.App.LookUp.Customer.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using GLib.CQRS.Validation.Abstractions;

namespace G_Pigmy.App.LookUp.Customer.Handlers
{
    public class GetCustomerHandler : AbstractQueryHandler<GetCustomerQuery, Response<GetCustomerResponse>>
    {
        private readonly ICustomerDataControl _customerDataControl;
        private readonly IMapper _mapper;
        public GetCustomerHandler(ICustomerDataControl customerDataControl, IMapper mapper, IValidator<GetCustomerQuery> validator) : base(validator) 
        {
            _customerDataControl = customerDataControl;
            _mapper = mapper;
        }

        protected override async Task<Response<GetCustomerResponse>> InternalHandleAsync(GetCustomerQuery query)
        {
            var customer = await _customerDataControl.GetById(query.Id.ToString());

            return new Response<GetCustomerResponse>
            {
                Data = _mapper.Map<GetCustomerResponse>(customer)
            };
        }
    }
}
