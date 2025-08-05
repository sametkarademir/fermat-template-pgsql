using System.Text.Json.Serialization;
using Fermat.Domain.Shared.DTOs;
using Fermat.Template.PgSql.Shared.Enums;

namespace Fermat.Template.PgSql.Application.DTOs.AppSettings;

public class AppSettingResponseDto : EntityDto<Guid>
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AppSettingType Type { get; set; }
    public bool IsEncrypted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public string? Group { get; set; }
    public string? Description { get; set; }
    public string? Environment { get; set; }
}