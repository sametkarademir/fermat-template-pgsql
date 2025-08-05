using System.Text.Json.Serialization;
using Fermat.Template.PgSql.Application.DTOs.Common;
using Fermat.Template.PgSql.Shared.Enums;
using FluentValidation;

namespace Fermat.Template.PgSql.Application.DTOs.AppSettings;

public class GetListAppSettingRequestDto : BaseGetListRequestDto
{
    public string? Key { get; set; } = null;
    public string? Environment { get; set; } = null;
    public string? Group { get; set; } = null;
    public bool? IsActive { get; set; } = null;
    public bool? IsEncrypted { get; set; } = null;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AppSettingType? Type { get; set; }
}

public class GetListAppSettingRequestValidator : AbstractValidator<GetListAppSettingRequestDto>
{
    public GetListAppSettingRequestValidator()
    {
        RuleFor(x => x.Key)
            .Matches(@"^[A-Za-z0-9._-]+$").WithMessage("Key must contain only alphanumeric characters, dots, underscores, and hyphens.")
            .MaximumLength(256)
            .When(x => !string.IsNullOrEmpty(x.Key));
        RuleFor(x => x.Environment)
            .MaximumLength(256)
            .When(x => !string.IsNullOrEmpty(x.Environment));
        RuleFor(x => x.Group)
            .MaximumLength(256)
            .When(x => !string.IsNullOrEmpty(x.Group));
        RuleFor(x => x.Type)
            .IsInEnum()
            .When(x => x.Type.HasValue);
    }
}