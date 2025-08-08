using Fermat.Domain.Shared.Auditing;
using Fermat.Template.PgSql.Shared.Enums;

namespace Fermat.Template.PgSql.Domain.Entities;

public class AppSetting : FullAuditedEntity<Guid>
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public AppSettingType Type { get; set; }
    public string? Description { get; set; }
    public string? Group { get; set; }
    public bool IsEncrypted { get; set; } = false;
    public bool IsActive { get; set; } = true;
}