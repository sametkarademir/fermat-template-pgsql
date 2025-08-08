using Fermat.EntityFramework.Shared.DTOs.Pagination;
using Fermat.Template.PgSql.Application.DTOs.AppSettings;
using Fermion.Template.PgSql.Application.DTOs.AppSettings;

namespace Fermat.Template.PgSql.Application.Services;

public interface IAppSettingAppService
{
    Task<AppSettingResponseDto> GetByIdAsync(Guid id);
    Task<AppSettingResponseDto> GetByKeyAsync(string key);
    Task<List<AppSettingResponseDto>> GetByGroupAsync(string group);
    Task<PageableResponseDto<AppSettingResponseDto>> GetPageableAndFilterAsync(GetListAppSettingRequestDto request);
    Task<AppSettingResponseDto> CreateAsync(CreateAppSettingRequestDto request);
    Task<AppSettingResponseDto> UpdateAsync(Guid id, UpdateAppSettingRequestDto request);
    Task DeleteAsync(Guid id);

    Task<bool> ExistsAsync(string key);
    Task ToggleActiveAsync(Guid id);
    Task ToggleEncryptionAsync(Guid id);
}