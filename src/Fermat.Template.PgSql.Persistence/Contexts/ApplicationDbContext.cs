using Fermat.EntityFramework.AuditLogs.Infrastructure.EntityConfigurations;
using Fermat.EntityFramework.ExceptionLogs.Infrastructure.EntityConfigurations;
using Fermat.EntityFramework.HttpRequestLogs.Infrastructure.EntityConfigurations;
using Fermat.EntityFramework.Identity.Infrastructure.Contexts;
using Fermat.EntityFramework.SnapshotLogs.Infrastructure.EntityConfigurations;
using Fermat.Template.PgSql.Domain.Entities;
using Fermat.Template.PgSql.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Fermat.Template.PgSql.Persistence.Contexts;

public class ApplicationDbContext : IdentityUserDbContext
{
    public DbSet<AppSetting> AppSettings { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Package
        builder.ApplyConfigurationsFromAssembly(typeof(AuditLogConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(EntityPropertyChangeConfiguration).Assembly);

        builder.ApplyConfigurationsFromAssembly(typeof(HttpRequestLogConfiguration).Assembly);

        builder.ApplyConfigurationsFromAssembly(typeof(ExceptionLogConfiguration).Assembly);

        builder.ApplyConfigurationsFromAssembly(typeof(SnapshotAppSettingConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(SnapshotAssemblyConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(SnapshotLogConfiguration).Assembly);
        #endregion

        builder.ApplyConfigurationsFromAssembly(typeof(AppSettingConfiguration).Assembly);
    }
}