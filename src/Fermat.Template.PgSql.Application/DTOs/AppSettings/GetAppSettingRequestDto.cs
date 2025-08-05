using FluentValidation;

namespace Fermat.Template.PgSql.Application.DTOs.AppSettings;

public class GetAppSettingRequestDto
{
    public string Key { get; set; } = null!;
    public string? Environment { get; set; }
}

public class GetAppSettingRequestValidator : AbstractValidator<GetAppSettingRequestDto>
{
    public GetAppSettingRequestValidator()
    {
        RuleFor(x => x.Key).MaximumLength(256).NotEmpty();
        RuleFor(x => x.Environment).MaximumLength(256);
    }
}