using FluentValidation;

namespace Fermion.Template.PgSql.Application.DTOs.AppSettings;

public class UpdateAppSettingRequestDto
{
    public string Value { get; set; } = null!;
    public bool IsEncrypted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public string? Group { get; set; }
    public string? Description { get; set; }
    public string? Environment { get; set; }
}

public class UpdateAppSettingRequestValidator : AbstractValidator<UpdateAppSettingRequestDto>
{
    public UpdateAppSettingRequestValidator()
    {
        RuleFor(x => x.Value).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(1024);
        RuleFor(x => x.Group).MaximumLength(256);
        RuleFor(x => x.Environment).MaximumLength(256);
    }
}