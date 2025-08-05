using AutoMapper;
using Fermat.Template.PgSql.Application.DTOs.AppSettings;
using Fermat.Template.PgSql.Domain.Entities;

namespace Fermat.Template.PgSql.Application.Profiles;

public class EntityProfiles : Profile
{
    public EntityProfiles()
    {
        CreateMap<AppSetting, AppSettingResponseDto>();
    }
}