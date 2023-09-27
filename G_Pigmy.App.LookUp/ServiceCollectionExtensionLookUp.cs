using G_Pigmy.App.LookUp.Agent.Handler;
using G_Pigmy.App.LookUp.Agent.Query;
using G_Pigmy.App.LookUp.Agent.Response;
using G_Pigmy.App.LookUp.Customer.Handlers;
using G_Pigmy.App.LookUp.Customer.Queries;
using G_Pigmy.App.LookUp.Customer.Response;
using G_Pigmy.App.LookUp.Transaction.Handler;
using G_Pigmy.App.LookUp.Transaction.Query;
using G_Pigmy.App.LookUp.Transaction.Response;
using GLib.Common;
using GLib.CQRS.Query.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace G_Pigmy.App.LookUp
{
    public static class ServiceCollectionExtensionLookUp
    {
        public static IServiceCollection AddLookUpServices(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetCustomerQuery, Response<GetCustomerResponse>>, GetCustomerHandler>();
            services.AddScoped<IQueryHandler<GetCustomersQuery, Response<IEnumerable<GetCustomerResponse>>>, GetCustomersHandler>();
            services.AddScoped<IQueryHandler<GetAgentQuery, Response<GetAgentResponse>>, GetAgentHandler>();
            services.AddScoped<IQueryHandler<TransactionQueryOnAgent, Response<IEnumerable<TransactionResponse>>>, GetTransactionByAgentHandler>();
            services.AddScoped<IQueryHandler<TransactionQueryOnCustomer, Response<IEnumerable<GetTransactionByCustomerResponse>>>, GetTransactionByCustomerHandler>();
            services.AddScoped<IQueryHandler<GetTransactionQueryOnDate, Response<IEnumerable<GetTransactionResponse>>>, GetTransactionByDateHandler>();

            return services;
        }
    }
}
