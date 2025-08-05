using Fermat.EntityFramework.AuditLogs.DependencyInjection;
using Fermat.EntityFramework.Shared.Extensions;
using Fermat.Template.PgSql.Application.Repositories;
using Fermat.Template.PgSql.Persistence.Contexts;
using Fermat.Template.PgSql.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fermat.Template.PgSql.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAppSettingRepository, AppSettingRepository>();

        var connectionString = configuration["ConnectionStrings:DefaultConnection"];
        services.AddDbContextFactory<ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
            opt.UseAuditLog();
            opt.UseEntityMetadataTracking();
            opt.UseOpenIddict();
        }, ServiceLifetime.Scoped);

        return services;
    }
}