using System.Data;

namespace G_Pigmy.App.Models
{
    public class Transaction
    {
        public string AccountId { get; set; } = string.Empty;

        public decimal OpeningBalance { get; set; }

        public decimal ClosingBalance { get; set; }

        public decimal Deposit { get; set; }

        public DateTime TimeStamp { get; set; }

        public string? AgentCode { get; set; }
    }
}
