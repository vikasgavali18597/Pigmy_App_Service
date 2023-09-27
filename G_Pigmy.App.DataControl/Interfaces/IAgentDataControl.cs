using G_Pigmy.App.Models;

namespace G_Pigmy.App.DataControl.Interfaces
{
    public interface IAgentDataControl
    {
        Task<Agent> GetAgentByIdAsync(string agentCode);
    }
}
