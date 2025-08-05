using Fermat.EntityFramework.Shared.DTOs.Pagination;
using Fermat.Template.PgSql.Application.DTOs.AppSettings;
using Fermion.Template.PgSql.Application.DTOs.AppSettings;

namespace Fermat.Template.PgSql.Application.Services;

public interface IAppSettingAppService
{
    #region CRUD Operations
    Task<AppSettingResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<AppSettingResponseDto> GetByKeyAsync(GetAppSettingRequestDto request, CancellationToken cancellationToken = default);
    Task<PageableResponseDto<AppSettingResponseDto>> GetPageableAndFilterAsync(GetListAppSettingRequestDto request, CancellationToken cancellationToken = default);

    Task<AppSettingResponseDto> CreateAsync(CreateAppSettingRequestDto request, CancellationToken cancellationToken = default);
    Task<AppSettingResponseDto> UpdateAsync(Guid id, UpdateAppSettingRequestDto request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion

    #region Utility Operations
    Task<bool> ExistsAsync(string key, string? environment = null, CancellationToken cancellationToken = default);
    Task ToggleActiveAsync(Guid id, CancellationToken cancellationToken = default);
    Task ToggleEncryptionAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion
}