using Azure;
using G_Pigmy.App.Models;
using GLib.Models.Azure.TableStorage;

namespace G_Pigmy.App.DataControl.Interfaces
{
    public interface ICustomerDataControl
    {
        Task<Customer> GetById(string partitionKey);

        Task<IEnumerable<Customer>> GetAllByAgentCodeAsync(string agentCode);

        Task<Customer> GetByCustomerAccountId(string accountId);
    }
}
