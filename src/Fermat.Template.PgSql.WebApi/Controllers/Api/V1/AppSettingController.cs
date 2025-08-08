using Fermat.EntityFramework.Shared.DTOs.Pagination;
using Fermat.Template.PgSql.Application.DTOs.AppSettings;
using Fermat.Template.PgSql.Application.Services;
using Fermion.Template.PgSql.Application.DTOs.AppSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fermat.Template.PgSql.WebApi.Controllers.Api.V1;

[ApiController]
[Route("api/v1/app-settings")]
[Authorize]
public class AppSettingController(IAppSettingAppService appSettingAppService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AppSettingResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] Guid id)
    {
        var result = await appSettingAppService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("exists")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ExistsAsync([FromQuery] string key)
    {
        var result = await appSettingAppService.ExistsAsync(key);
        return Ok(result);
    }

    [HttpGet("{key:}/key")]
    [ProducesResponseType(typeof(AppSettingResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByKeyAsync([FromRoute(Name = "key")] string key)
    {
        var result = await appSettingAppService.GetByKeyAsync(key);
        return Ok(result);
    }
    
    [HttpGet("{group:}/group")]
    [ProducesResponseType(typeof(List<AppSettingResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByGroupAsync([FromRoute(Name = "group")] string group)
    {
        var result = await appSettingAppService.GetByGroupAsync(group);
        return Ok(result);
    }

    [HttpGet("pageable")]
    [ProducesResponseType(typeof(PageableResponseDto<AppSettingResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPageableAndFilterAsync([FromQuery] GetListAppSettingRequestDto request)
    {
        var result = await appSettingAppService.GetPageableAndFilterAsync(request);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AppSettingResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAppSettingRequestDto request)
    {
        var result = await appSettingAppService.CreateAsync(request);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(AppSettingResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] Guid id, [FromBody] UpdateAppSettingRequestDto request)
    {
        var result = await appSettingAppService.UpdateAsync(id, request);
        return Ok(result);
    }

    [HttpPut("{id:guid}/toggle-active")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ToggleActiveAsync([FromRoute(Name = "id")] Guid id)
    {
        await appSettingAppService.ToggleActiveAsync(id);
        return NoContent();
    }

    [HttpPut("{id:guid}/toggle-encryption")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ToggleEncryptionAsync([FromRoute(Name = "id")] Guid id)
    {
        await appSettingAppService.ToggleEncryptionAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] Guid id)
    {
        await appSettingAppService.DeleteAsync(id);
        return NoContent();
    }
}