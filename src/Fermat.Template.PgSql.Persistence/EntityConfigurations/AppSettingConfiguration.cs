using Fermat.EntityFramework.Shared.Extensions;
using Fermat.Template.PgSql.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fermat.Template.PgSql.Persistence.EntityConfigurations;

public class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
{
    public void Configure(EntityTypeBuilder<AppSetting> builder)
    {
        builder.ApplyGlobalEntityConfigurations();

        builder.ToTable("AppSettings");
        builder.HasIndex(item => new { item.Key, item.DeletionTime }).IsUnique();
        builder.HasIndex(item => item.Type);
        builder.HasIndex(item => item.Group);
        builder.HasIndex(item => item.IsActive);

        builder.Property(item => item.Key).HasMaxLength(256).IsRequired();
        builder.Property(item => item.Value).HasMaxLength(1024).IsRequired();
        builder.Property(item => item.Description).HasMaxLength(1024);
        builder.Property(item => item.Group).HasMaxLength(256);
    }
}