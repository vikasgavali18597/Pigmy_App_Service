using GLib.Models.Azure.TableStorage;

namespace G_Pigmy.App.DbModels
{
    public class Customer : BaseModel
    {
        public string AccountNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string OpeningBalance { get; set; } = string.Empty;

        public string ClosingBalance { get; set; } = string.Empty;

        public DateTime AccountOpeningDate { get; set; }
        
        public string AgentCode { get; set; } = string.Empty;

        public string BranchCode { get; set; } = string.Empty;

        public string BranchName { get; set; } = string.Empty;
    }
}
