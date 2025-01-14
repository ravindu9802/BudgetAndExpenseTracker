using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Domain.Repositories.Expenses;
using Tracker.Domain.Repositories.Incomes;
using Tracker.Domain.Repositories.Users;
using Tracker.Infrastructure.Persistence;
using Tracker.Infrastructure.Repositories.Expenses;
using Tracker.Infrastructure.Repositories.Incomes;
using Tracker.Infrastructure.Repositories.Users;

namespace Tracker.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection InfrastructureExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("UserDbConnection"));
        });

        services.AddDbContext<IncomeDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("IncomeDbConnection"));
        });

        services.AddDbContext<ExpenseDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ExpenseDbConnection"));
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserUoW, UserUoW>();
        services.AddScoped<IIncomeRepository, IncomeRepository>();
        services.AddScoped<IIncomeUoW, IncomeUoW>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IExpenseUoW, ExpenseUoW>();

        return services;
    }
}
