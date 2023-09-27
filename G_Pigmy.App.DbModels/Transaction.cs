using GLib.Models.Azure.TableStorage;

namespace G_Pigmy.App.DbModels
{
    public class Transaction : BaseModel
    {
        public string AccountId { get; set; } = string.Empty;

        public decimal OpeningBalance { get; set; }

        public decimal ClosingBalance { get; set; }

        public decimal Deposit { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
