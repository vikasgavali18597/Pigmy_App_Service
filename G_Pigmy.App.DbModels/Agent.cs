using GLib.Models.Azure.TableStorage;

namespace G_Pigmy.App.DbModels
{
    public class Agent : BaseModel
    {
        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string BranchCode { get; set; } = string.Empty;

        public string? Mobile { get; set; }
    }
}
