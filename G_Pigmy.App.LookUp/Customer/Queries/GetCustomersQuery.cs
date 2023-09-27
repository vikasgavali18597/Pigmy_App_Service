using GLib.CQRS.Query.Abstractions;

namespace G_Pigmy.App.LookUp.Customer.Queries
{
    public class GetCustomersQuery : IQuery
    {
        public string? AgentCode { get; set; }
    }
}
