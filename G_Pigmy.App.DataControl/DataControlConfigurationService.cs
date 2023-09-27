using G_Pigmy.App.DataControl.Implementations;
using G_Pigmy.App.DataControl.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace G_Pigmy.App.DataControl
{
    public static class DataControlConfigurationService
    {
        public static IServiceCollection AddDataControlServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICustomerDataControl, CustomerDataControl>();
            services.AddScoped<IAgentDataControl, AgentDataControl>();
            services.AddScoped<IUtility, Utility>();
            services.AddScoped<ITransactionDataControl, TransactionDateControl>();
            return services;
        }
    }
}
