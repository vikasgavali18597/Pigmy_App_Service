using GLib.CQRS.Query.Abstractions;
using System.Runtime.CompilerServices;

namespace G_Pigmy.App.LookUp.Transaction.Query
{
    public class TransactionQueryOnCustomer : IQuery
    {
        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public string CustomerId { get; set; } = string.Empty;
    }
}
