using System.Text.Json.Serialization;
using Fermat.Template.PgSql.Shared.Enums;
using FluentValidation;

namespace Fermat.Template.PgSql.Application.DTOs.AppSettings;

public class CreateAppSettingRequestDto
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

public class CreateAppSettingRequestValidator : AbstractValidator<CreateAppSettingRequestDto>
{
    public CreateAppSettingRequestValidator()
    {
        RuleFor(x => x.Key)
            .Matches(@"^[A-Za-z0-9._-]+$").WithMessage("Key must contain only alphanumeric characters, dots, underscores, and hyphens.")
            .MaximumLength(256)
            .NotEmpty();
        RuleFor(x => x.Value).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(1024);
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.Group).MaximumLength(256);
        RuleFor(x => x.Environment).MaximumLength(256);
    }
}