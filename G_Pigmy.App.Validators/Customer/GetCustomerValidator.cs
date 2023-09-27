using FluentValidation;
using G_Pigmy.App.LookUp.Customer.Queries;

namespace G_Pigmy.App.Validators.Customer
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
