using G_Pigmy.App.Mutation.Transaction.Command;
using G_Pigmy.App.Mutation.Transaction.Handler;
using GLib.Common;
using GLib.CQRS.Command.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Pigmy.App.Mutation
{
    public static class ServiceCollectionExtensionMutation
    {
        public static IServiceCollection AddMutation(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<TransactionCommand, Response>, TransactionHandler>();
            return services;
        }
    }
}
