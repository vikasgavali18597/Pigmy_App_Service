using FluentValidation;
using G_Pigmy.App.LookUp.Transaction.Query;

namespace G_Pigmy.App.Validators.Transaction
{
    public class GetTransactionByDateValidator : AbstractValidator<GetTransactionQueryOnDate>
    {
        public GetTransactionByDateValidator()
        {
            RuleFor(x => x.AgentCode).NotNull().NotEmpty();
            RuleFor(x => x.Date).NotNull().NotEmpty();
        }
    }
}
