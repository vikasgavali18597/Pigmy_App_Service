using GLib.CQRS.Query.Abstractions;

namespace G_Pigmy.App.LookUp.Agent.Query
{
    public class GetAgentQuery : IQuery
    {
        public string? AgentCode { get; set; }
    }
}
