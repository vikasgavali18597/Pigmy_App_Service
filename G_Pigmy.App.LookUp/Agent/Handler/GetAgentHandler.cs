using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.LookUp.Agent.Query;
using G_Pigmy.App.LookUp.Agent.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using GLib.CQRS.Validation.Abstractions;

namespace G_Pigmy.App.LookUp.Agent.Handler
{
    public class GetAgentHandler : AbstractQueryHandler<GetAgentQuery, Response<GetAgentResponse>>
    {
        private readonly IAgentDataControl _agentDataControl;
        public GetAgentHandler(IAgentDataControl agentDataControl, IValidator<GetAgentQuery> validator) : base(validator)
        {
            _agentDataControl = agentDataControl;
        }

        protected override async Task<Response<GetAgentResponse>> InternalHandleAsync(GetAgentQuery query)
        {
            var agent = await _agentDataControl.GetAgentByIdAsync(query.AgentCode!);
            return new Response<GetAgentResponse>
            {
                Data = new GetAgentResponse
                {
                    Name = agent.Name,
                    BranchCode = agent.BranchCode,
                    Code = agent.Code,
                }
            };
        }
    }
}
