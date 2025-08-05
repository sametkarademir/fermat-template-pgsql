using Fermat.Template.PgSql.Application.Services;
using Fermat.Template.PgSql.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fermat.Template.PgSql.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureExtensions(this IServiceCollection services)
    {
        services.AddScoped<IAppSettingAppService, AppSettingAppService>();

        return services;
    }
}