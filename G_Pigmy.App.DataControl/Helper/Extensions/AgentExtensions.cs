using G_Pigmy.App.Models;
using System.Runtime.CompilerServices;
using db = G_Pigmy.App.DbModels;
namespace G_Pigmy.App.DataControl.Helper.Extensions
{
    public static class AgentExtensions
    {
        public static Agent ToAgent(this db.Agent agent)
        {
            return new Agent
            {
                Id = new Guid(agent.RowKey!),
                Name = agent.Name,
                BranchCode = agent.BranchCode,
                Code = agent.Code,
            };
        }
    }
}
