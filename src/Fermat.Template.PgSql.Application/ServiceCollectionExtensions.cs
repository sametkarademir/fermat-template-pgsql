using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Fermat.Template.PgSql.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}