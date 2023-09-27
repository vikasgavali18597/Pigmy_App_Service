using FluentValidation;
using G_Pigmy.App.LookUp.Agent.Query;
using G_Pigmy.App.LookUp.Customer.Queries;
using G_Pigmy.App.LookUp.Transaction.Query;
using G_Pigmy.App.Mutation.Transaction.Command;
using G_Pigmy.App.Mutation.Transaction.Handler;
using G_Pigmy.App.Validators.Agent;
using G_Pigmy.App.Validators.Customer;
using G_Pigmy.App.Validators.Transaction;
using GLib.CQRS.Validation.FluentValidator;
using Microsoft.Extensions.DependencyInjection;

namespace G_Pigmy.App.Validators
{
    public static class ValidatorServiceCollection
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services
                .AddFluentValidator()
                .AddSingleton<AbstractValidator<GetCustomerQuery>,  GetCustomerValidator>()
                .AddSingleton<AbstractValidator<GetCustomersQuery>, GetCustomersValidator>()
                .AddSingleton<AbstractValidator<GetAgentQuery>, GetAgentValidator>()
                .AddSingleton<AbstractValidator<TransactionQueryOnCustomer>, GetTransactionByCustomerValidator>()
                .AddSingleton<AbstractValidator<TransactionQueryOnAgent>, GetTransactionByAgentValidator>()
                .AddSingleton<AbstractValidator<TransactionCommand>, TransactionValidator>()
                .AddSingleton<AbstractValidator<GetTransactionQueryOnDate>, GetTransactionByDateValidator>()
                ;
        }
    }
}
    