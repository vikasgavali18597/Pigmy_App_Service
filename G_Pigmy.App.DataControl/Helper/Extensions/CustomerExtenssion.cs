using G_Pigmy.App.Models;
using db = G_Pigmy.App.DbModels;

namespace G_Pigmy.App.DataControl.Helper.Extensions
{
    public static class CustomerExtension
    {
        public static Customer ToCustomer(this db.Customer customer)
        {
            return new Customer
            {
                Id = new Guid(customer.RowKey!),
                Name = customer.Name,
                AccountNumber = customer.AccountNumber,
                AccountOpeningDate = customer.AccountOpeningDate,
                AvailableBalance = Convert.ToDecimal(customer.ClosingBalance),
                CurrentBalance = Convert.ToDecimal(customer.OpeningBalance)
            };
        }
    }
}
