using Fermat.EntityFramework.Shared.DTOs.Pagination;
using Fermat.Template.PgSql.Application.DTOs.AppSettings;
using Fermat.Template.PgSql.Application.Services;
using Fermion.Template.PgSql.Application.DTOs.AppSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fermat.Template.PgSql.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AppSettingController(IAppSettingAppService appSettingAppService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AppSettingResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await appSettingAppService.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpGet("exists")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ExistsAsync([FromQuery] string key, [FromQuery] string? environment = null, CancellationToken cancellationToken = default)
    {
        var result = await appSettingAppService.ExistsAsync(key, environment, cancellationToken);
        return Ok(result);
    }

    [HttpGet("key")]
    public async Task<IActionResult> GetByKeyAsync([FromQuery] GetAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var result = await appSettingAppService.GetByKeyAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("pageable")]
    [ProducesResponseType(typeof(PageableResponseDto<AppSettingResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPageableAndFilterAsync([FromQuery] GetListAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var result = await appSettingAppService.GetPageableAndFilterAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AppSettingResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var result = await appSettingAppService.CreateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(AppSettingResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] Guid id, [FromBody] UpdateAppSettingRequestDto request, CancellationToken cancellationToken = default)
    {
        var result = await appSettingAppService.UpdateAsync(id, request, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}/toggle-active")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ToggleActiveAsync([FromRoute(Name = "id")] Guid id, CancellationToken cancellationToken = default)
    {
        await appSettingAppService.ToggleActiveAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/toggle-encryption")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ToggleEncryptionAsync([FromRoute(Name = "id")] Guid id, CancellationToken cancellationToken = default)
    {
        await appSettingAppService.ToggleEncryptionAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] Guid id, CancellationToken cancellationToken = default)
    {
        await appSettingAppService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}