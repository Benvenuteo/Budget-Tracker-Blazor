using BudgetTracker.Application.Interfaces;
using BudgetTracker.Application.Mappings;
using BudgetTracker.Application.Services;
using BudgetTracker.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateTransactionDtoValidator>();

            services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
