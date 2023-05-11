using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;

[ApiController]
[Route("api/TicketTypes")]
public class TicketTypeController : ControllerBase
{
    private readonly ITicketTypeService _ticketTypeService;
    private readonly ILogger<TicketTypeController> _logger;
    const string NAMEOFCONTROLLER = "Loại vé";

    public TicketTypeController(ITicketTypeService ticketTypeService, ILogger<TicketTypeController> logger)
    {
        _ticketTypeService = ticketTypeService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTicketTypes()
    {
        _logger.LogInformation("get");
        try
        {
            var ticketType = await _ticketTypeService.GetAllTicketTypesAsync();
            return ticketType == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Đã xảy ra lỗi",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = ticketType,
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
    public async Task<IActionResult> GetTicketTypeById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var ticketType = await _ticketTypeService.GetTicketTypeByIdAsync(id);
            return ticketType == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "" + NAMEOFCONTROLLER + " này không tồn tại",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = ticketType,
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
    public async Task<IActionResult> AddTicketType(TicketType ticketType)
    {
        _logger.LogInformation("Creating a new TicketType");

        try
        {
            await _ticketTypeService.AddTicketTypeAsync(ticketType);
            var result = CreatedAtAction(nameof(GetTicketTypeById), new { id = ticketType.TicketTypeId }, ticketType);
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
    public async Task<IActionResult> UpdateTicketType(int id, [FromBody] TicketType ticketType)
    {

        _logger.LogInformation("update a TicketType");

        if (id != ticketType.TicketTypeId)
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
            await _ticketTypeService.UpdateTicketTypeAsync(id, ticketType);
            var result = CreatedAtAction(nameof(GetTicketTypeById), new { id = ticketType.TicketTypeId }, ticketType);
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
    public async Task<IActionResult> DeleteTicketType(int id)
    {
        await _ticketTypeService.DeleteTicketTypeAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Delete success",
            Success = true,
        });

    }
}
