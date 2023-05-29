using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/Permissions")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;
    private readonly ILogger<PermissionController> _logger;
    const string NAMEOFCONTROLLER = "Permission";

    public PermissionController(IPermissionService permissionService, ILogger<PermissionController> logger)
    {
        _permissionService = permissionService;
        _logger = logger;
    }

    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllPermissions()
    {
        _logger.LogInformation("get");
        try
        {
            var Permission = await _permissionService.GetAllPermissionsAsync();

            return Permission == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Đã xảy ra lỗi",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = Permission,
                Message = "lấy ra tất cả " + NAMEOFCONTROLLER + " thành công",
                Success = true
            });
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest(new ApiResponse
            {
                Data = null,
                Message = "lấy ra tất cả " + NAMEOFCONTROLLER + " thật bại",
                Success = false
            });
        }
    }

    [HttpGet("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetPermissionById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var Permission = await _permissionService.GetPermissionByIdAsync(id);
            return Permission == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "" + NAMEOFCONTROLLER + " này không tồn tại",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = Permission,
                Message = "lấy ra " + NAMEOFCONTROLLER + " thành công",
                Success = true
            });
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest(new ApiResponse
            {
                Data = null,
                Message = "Lỗi ",
                Success = false
            });
        }
    }

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddPermission(Permission Permission)
    {
        _logger.LogInformation("Creating a new Permission");

        try
        {
            await _permissionService.AddPermissionAsync(Permission);
            var result = CreatedAtAction(nameof(GetPermissionById), new { id = Permission.PermissionId }, Permission);
            return Ok(new ApiResponse
            {
                Data = result,
                Message = "Thêm mới " + NAMEOFCONTROLLER + " thành công",
                Success = true
            });
        }
        catch (System.Exception)
        {

            return BadRequest(new ApiResponse
            {
                Data = null,
                Message = "Thêm mới " + NAMEOFCONTROLLER + " thất bại",
                Success = false
            });
        }

    }

    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdatePermission(int id, [FromBody] Permission Permission)
    {

        _logger.LogInformation("update a Permission");

        if (id != Permission.PermissionId)
        {
            return NotFound(new ApiResponse
            {
                Data = null,
                Message = "Không tìm thấy " + NAMEOFCONTROLLER + "",
                Success = false,
            });
        }
        try
        {
            await _permissionService.UpdatePermissionAsync(id, Permission);
            var result = CreatedAtAction(nameof(GetPermissionById), new { id = Permission.PermissionId }, Permission);
            return Ok(new ApiResponse
            {
                Data = result,
                Success = true,
                Message = "Update " + NAMEOFCONTROLLER + " thành công"
            });
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest(new ApiResponse
            {
                Data = null,
                Message = "Update fail",
                Success = false,
            });
        }
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePermission(int id)
    {
        await _permissionService.DeletePermissionAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Delete success",
            Success = true,
        });

    }
}
