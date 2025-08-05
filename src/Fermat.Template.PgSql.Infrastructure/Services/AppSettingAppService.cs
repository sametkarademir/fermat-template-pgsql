using AutoMapper;
using Fermat.Domain.Exceptions.Types;
using Fermat.Domain.Extensions.Linq;
using Fermat.EntityFramework.Shared.DTOs.Pagination;
using Fermat.EntityFramework.Shared.Extensions;
using Fermat.Template.PgSql.Application.DTOs.AppSettings;
using Fermat.Template.PgSql.Application.Repositories;
using Fermat.Template.PgSql.Application.Services;
using Fermat.Template.PgSql.Domain.Entities;
using Fermion.Template.PgSql.Application.DTOs.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace Fermat.Template.PgSql.Infrastructure.Services;

public class AppSettingAppService(
    IAppSettingRepository appSettingRepository,
    IMapper mapper)
    : IAppSettingAppService
{
    public async Task<AppSettingResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id, cancellationToken: cancellationToken);

        return mapper.Map<AppSettingResponseDto>(matchedAppSetting);
    }

    public async Task<AppSettingResponseDto> GetByKeyAsync(GetAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(item =>
            item.Key == request.Key &&
            item.Environment == request.Environment,
            cancellationToken: cancellationToken
        );

        return mapper.Map<AppSettingResponseDto>(matchedAppSetting);
    }

    public async Task<PageableResponseDto<AppSettingResponseDto>> GetPageableAndFilterAsync(GetListAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var queryable = appSettingRepository.GetQueryable();
        queryable = queryable.WhereIf(!string.IsNullOrEmpty(request.Key), item => item.Key == request.Key);
        queryable = queryable.WhereIf(!string.IsNullOrEmpty(request.Environment), item => item.Environment == request.Environment);
        queryable = queryable.WhereIf(!string.IsNullOrEmpty(request.Group), item => item.Group == request.Group);
        queryable = queryable.WhereIf(request.IsActive.HasValue, item => item.IsActive == request.IsActive);
        queryable = queryable.WhereIf(request.IsEncrypted.HasValue, item => item.IsEncrypted == request.IsEncrypted);
        queryable = queryable.WhereIf(request.Type.HasValue, item => item.Type == request.Type);

        queryable = queryable.AsNoTracking();
        queryable = queryable.ApplySort(request.Field, request.Order, cancellationToken);
        var result = await queryable.ToPageableAsync(request.Page, request.PerPage, cancellationToken: cancellationToken);
        var mappedAppSettings = mapper.Map<List<AppSettingResponseDto>>(result.Data);

        return new PageableResponseDto<AppSettingResponseDto>(mappedAppSettings, result.Meta);
    }

    public async Task<AppSettingResponseDto> CreateAsync(CreateAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var existingAppSetting = await appSettingRepository.AnyAsync(item =>
            item.Key == request.Key &&
            item.Environment == request.Environment,
            cancellationToken: cancellationToken
        );

        if (existingAppSetting)
        {
            throw new AppUserFriendlyException($"An app setting with key '{request.Key}' and environment '{request.Environment}' already exists.");
        }

        var newAppSetting = new AppSetting
        {
            Key = request.Key,
            Value = request.Value,
            Description = request.Description,
            Type = request.Type,
            IsEncrypted = request.IsEncrypted,
            Group = request.Group,
            IsActive = request.IsActive,
            Environment = request.Environment
        };

        newAppSetting = await appSettingRepository.AddAsync(newAppSetting, cancellationToken: cancellationToken);
        await appSettingRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<AppSettingResponseDto>(newAppSetting);
    }

    public async Task<AppSettingResponseDto> UpdateAsync(Guid id, UpdateAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id, cancellationToken: cancellationToken);

        matchedAppSetting.Value = request.Value;
        matchedAppSetting.Description = request.Description;
        matchedAppSetting.IsEncrypted = request.IsEncrypted;
        matchedAppSetting.Group = request.Group;
        matchedAppSetting.IsActive = request.IsActive;
        matchedAppSetting.Environment = request.Environment;

        await appSettingRepository.UpdateAsync(matchedAppSetting, cancellationToken: cancellationToken);
        await appSettingRepository.SaveChangesAsync(cancellationToken);

        return mapper.Map<AppSettingResponseDto>(matchedAppSetting);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id, cancellationToken: cancellationToken);

        await appSettingRepository.DeleteAsync(matchedAppSetting, cancellationToken: cancellationToken);
        await appSettingRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(string key, string? environment = null, CancellationToken cancellationToken = default)
    {
        var exists = await appSettingRepository.AnyAsync(item =>
            item.Key == key &&
            (environment == null || item.Environment == environment),
            cancellationToken: cancellationToken);

        return exists;
    }

    public async Task ToggleActiveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id, cancellationToken: cancellationToken);

        matchedAppSetting.IsActive = !matchedAppSetting.IsActive;

        await appSettingRepository.UpdateAsync(matchedAppSetting, cancellationToken: cancellationToken);
        await appSettingRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task ToggleEncryptionAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id, cancellationToken: cancellationToken);

        matchedAppSetting.IsEncrypted = !matchedAppSetting.IsEncrypted;

        await appSettingRepository.UpdateAsync(matchedAppSetting, cancellationToken: cancellationToken);
        await appSettingRepository.SaveChangesAsync(cancellationToken);
    }
}