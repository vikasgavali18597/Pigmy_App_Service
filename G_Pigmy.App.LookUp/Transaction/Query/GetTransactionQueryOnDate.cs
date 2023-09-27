using GLib.CQRS.Query.Abstractions;
namespace G_Pigmy.App.LookUp.Transaction.Query
{
    public class GetTransactionQueryOnDate : IQuery
    {
        public string? AgentCode { get; set; }

        public string? Date { get; set; }
    }
}
