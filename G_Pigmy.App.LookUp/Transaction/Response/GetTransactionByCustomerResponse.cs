﻿namespace G_Pigmy.App.LookUp.Transaction.Response
{
    public class GetTransactionByCustomerResponse
    {
        public string AccountId { get; set; } = string.Empty;

        public decimal OpeningBalance { get; set; }

        public decimal ClosingBalance { get; set; }

        public decimal Deposit { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
