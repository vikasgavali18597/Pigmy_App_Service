namespace G_Pigmy.App.LookUp.Customer.Response
{
    public class GetCustomerResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string AccountNumber { get; set; } = string.Empty;

        public DateTime AccountOpeningDate { get; set; }

        public decimal CurrentBalance { get; set; }

        public decimal AvailableBalance { get; set; }
    }
}
