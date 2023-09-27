using FluentValidation;
using G_Pigmy.App.LookUp.Customer.Queries;

namespace G_Pigmy.App.Validators.Customer
{
    public  class GetCustomersValidator : AbstractValidator<GetCustomersQuery>
    {
        public GetCustomersValidator()
        {
            RuleFor(x => x.AgentCode).NotNull().NotEmpty();
        }
    }
}
