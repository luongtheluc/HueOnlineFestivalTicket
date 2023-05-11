using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;

[ApiController]
[Route("api/Roles")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _RoleService;
    private readonly ILogger<RoleController> _logger;
    const string NAMEOFCONTROLLER = "Role";

    public RoleController(IRoleService RoleService, ILogger<RoleController> logger)
    {
        _RoleService = RoleService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        _logger.LogInformation("get");
        try
        {
            var role = await _RoleService.GetAllRolesAsync();
            return role == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Đã xảy ra lỗi",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = role,
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var role = await _RoleService.GetRoleByIdAsync(id);
            return role == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "" + NAMEOFCONTROLLER + " này không tồn tại",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = role,
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

    [HttpPost]
    public async Task<IActionResult> AddRole(Role role)
    {
        _logger.LogInformation("Creating a new Role");

        try
        {
            await _RoleService.AddRoleAsync(role);
            var result = CreatedAtAction(nameof(GetRoleById), new { id = role.RoleId }, role);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, [FromBody] Role role)
    {

        _logger.LogInformation("update a Role");

        if (id != role.RoleId)
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
            await _RoleService.UpdateRoleAsync(id, role);
            var result = CreatedAtAction(nameof(GetRoleById), new { id = role.RoleId }, role);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        await _RoleService.DeleteRoleAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Delete success",
            Success = true,
        });

    }
}
