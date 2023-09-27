using FluentValidation;
using G_Pigmy.App.LookUp.Transaction.Query;

namespace G_Pigmy.App.Validators.Transaction
{
    public class GetTransactionByCustomerValidator : AbstractValidator<TransactionQueryOnCustomer>
    {
        public GetTransactionByCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty().NotNull();
            RuleFor(x => x.EndDate).NotEmpty().NotNull();
        }
    }
}
