using FluentValidation;
using G_Pigmy.App.LookUp.Agent.Query;

namespace G_Pigmy.App.Validators.Agent
{
    internal class GetAgentValidator : AbstractValidator<GetAgentQuery>
    {
        public GetAgentValidator()
        {
            RuleFor(x => x.AgentCode).NotNull().NotEmpty();
        }
    }
}
