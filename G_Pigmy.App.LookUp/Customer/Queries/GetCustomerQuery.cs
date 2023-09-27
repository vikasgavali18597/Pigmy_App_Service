using GLib.CQRS.Query.Abstractions;

namespace G_Pigmy.App.LookUp.Customer.Queries
{
    public class GetCustomerQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
