using FluentValidation;
using G_Pigmy.App.LookUp.Transaction.Query;

namespace G_Pigmy.App.Validators.Transaction
{
    public class GetTransactionByAgentValidator : AbstractValidator<TransactionQueryOnAgent>
    {
        public GetTransactionByAgentValidator()
        {
            RuleFor(x => x.AgentCode).NotEmpty().NotNull();
        }
    }
}
