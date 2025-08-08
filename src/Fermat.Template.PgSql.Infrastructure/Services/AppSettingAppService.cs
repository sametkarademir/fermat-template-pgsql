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
    public async Task<AppSettingResponseDto> GetByIdAsync(Guid id)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id);

        return mapper.Map<AppSettingResponseDto>(matchedAppSetting);
    }
    
    public async Task<AppSettingResponseDto> GetByKeyAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new AppUserFriendlyException("The key cannot be null or empty.");
        }

        var matchedAppSetting = await appSettingRepository.GetAsync(item => item.Key == key);

        return mapper.Map<AppSettingResponseDto>(matchedAppSetting);
    }

    public async Task<List<AppSettingResponseDto>> GetByGroupAsync(string group)
    {
        if (string.IsNullOrEmpty(group))
        {
            throw new AppUserFriendlyException("The group cannot be null or empty.");
        }

        var matchedAppSettings = await appSettingRepository.GetAllAsync(item => item.Group == group);

        return mapper.Map<List<AppSettingResponseDto>>(matchedAppSettings);
    }
    
    public async Task<PageableResponseDto<AppSettingResponseDto>> GetPageableAndFilterAsync(GetListAppSettingRequestDto request)
    {
        var queryable = appSettingRepository.GetQueryable();
        queryable = queryable.WhereIf(!string.IsNullOrEmpty(request.Key), item => item.Key == request.Key);
        queryable = queryable.WhereIf(!string.IsNullOrEmpty(request.Group), item => item.Group == request.Group);
        queryable = queryable.WhereIf(request.IsActive.HasValue, item => item.IsActive == request.IsActive);
        queryable = queryable.WhereIf(request.IsEncrypted.HasValue, item => item.IsEncrypted == request.IsEncrypted);
        queryable = queryable.WhereIf(request.Type.HasValue, item => item.Type == request.Type);

        queryable = queryable.AsNoTracking();
        queryable = queryable.ApplySort(request.Field, request.Order);
        var result = await queryable.ToPageableAsync(request.Page, request.PerPage);
        var mappedAppSettings = mapper.Map<List<AppSettingResponseDto>>(result.Data);

        return new PageableResponseDto<AppSettingResponseDto>(mappedAppSettings, result.Meta);
    }

    public async Task<AppSettingResponseDto> CreateAsync(CreateAppSettingRequestDto request)
    {
        var existingAppSetting = await ExistsAsync(request.Key);
        if (existingAppSetting)
        {
            throw new AppUserFriendlyException($"An app setting with key '{request.Key}' already exists.");
        }

        var newAppSetting = new AppSetting
        {
            Key = request.Key,
            Value = request.Value,
            Description = request.Description,
            Type = request.Type,
            IsEncrypted = request.IsEncrypted,
            Group = request.Group,
            IsActive = request.IsActive
        };

        newAppSetting = await appSettingRepository.AddAsync(newAppSetting);
        await appSettingRepository.SaveChangesAsync();

        return mapper.Map<AppSettingResponseDto>(newAppSetting);
    }

    public async Task<AppSettingResponseDto> UpdateAsync(Guid id, UpdateAppSettingRequestDto request)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id);

        matchedAppSetting.Value = request.Value;
        matchedAppSetting.Description = request.Description;
        matchedAppSetting.IsEncrypted = request.IsEncrypted;
        matchedAppSetting.Group = request.Group;
        matchedAppSetting.IsActive = request.IsActive;

        await appSettingRepository.UpdateAsync(matchedAppSetting);
        await appSettingRepository.SaveChangesAsync();

        return mapper.Map<AppSettingResponseDto>(matchedAppSetting);
    }

    public async Task DeleteAsync(Guid id)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id);

        await appSettingRepository.DeleteAsync(matchedAppSetting);
        await appSettingRepository.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string key)
    {
        var exists = await appSettingRepository.AnyAsync(item => item.Key == key);

        return exists;
    }

    public async Task ToggleActiveAsync(Guid id)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id);

        matchedAppSetting.IsActive = !matchedAppSetting.IsActive;

        await appSettingRepository.UpdateAsync(matchedAppSetting);
        await appSettingRepository.SaveChangesAsync();
    }

    public async Task ToggleEncryptionAsync(Guid id)
    {
        var matchedAppSetting = await appSettingRepository.GetAsync(id);

        matchedAppSetting.IsEncrypted = !matchedAppSetting.IsEncrypted;

        await appSettingRepository.UpdateAsync(matchedAppSetting);
        await appSettingRepository.SaveChangesAsync();
    }
}