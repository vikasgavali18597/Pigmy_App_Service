using GLib.CQRS.Query.Abstractions;

namespace G_Pigmy.App.LookUp.Transaction.Query
{
    public class TransactionQueryOnAgent : IQuery
    {
        public string AgentCode { get; set; }
    }
}
