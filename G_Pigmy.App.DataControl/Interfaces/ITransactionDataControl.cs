using G_Pigmy.App.Models;
using GLib.Common;

namespace G_Pigmy.App.DataControl.Interfaces
{
    public interface ITransactionDataControl
    {
        Task<IEnumerable<Transaction>> GetTransactionsByAgentAsync(string agentCode);

        Task<IEnumerable<Transaction>> GetTransactionsCustomerAsync(string accountId, string startDate, string endDate);

        Task<Response> AddTransactionAsync(Transaction transaction);

        Task<IEnumerable<Transaction>> GetTransactionsByDate(string code, string  date);

    }
}
