using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;

[ApiController]
[Route("api/TicketCheckins")]
public class TicketCheckinController : ControllerBase
{
    private readonly ITicketCheckinService _ticketCheckinService;
    private readonly ILogger<TicketCheckinController> _logger;
    const string NAMEOFCONTROLLER = "checkin";

    public TicketCheckinController(ITicketCheckinService ticketCheckinService, ILogger<TicketCheckinController> logger)
    {
        _ticketCheckinService = ticketCheckinService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllticketCheckins()
    {
        _logger.LogInformation("get");
        try
        {
            var ticketCheckin = await _ticketCheckinService.GetAllTicketCheckinsAsync();
            return ticketCheckin == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Đã xảy ra lỗi",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = ticketCheckin,
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
    public async Task<IActionResult> GetticketCheckinById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var ticketCheckin = await _ticketCheckinService.GetTicketCheckinByIdAsync(id);
            return ticketCheckin == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "" + NAMEOFCONTROLLER + " này không tồn tại",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = ticketCheckin,
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
    public async Task<IActionResult> AddticketCheckin(TicketCheckin ticketCheckin)
    {
        _logger.LogInformation("Creating a new ticketCheckin");

        try
        {
            await _ticketCheckinService.AddTicketCheckinAsync(ticketCheckin);
            var result = CreatedAtAction(nameof(GetticketCheckinById), new { id = ticketCheckin.TicketCheckinId }, ticketCheckin);
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
    public async Task<IActionResult> UpdateticketCheckin(int id, [FromBody] TicketCheckin ticketCheckin)
    {

        _logger.LogInformation("update a ticketCheckin");

        if (id != ticketCheckin.TicketCheckinId)
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
            await _ticketCheckinService.UpdateTicketCheckinAsync(id, ticketCheckin);
            var result = CreatedAtAction(nameof(GetticketCheckinById), new { id = ticketCheckin.TicketCheckinId }, ticketCheckin);
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
    public async Task<IActionResult> DeleteticketCheckin(int id)
    {
        await _ticketCheckinService.DeleteTicketCheckinAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Delete success",
            Success = true,
        });

    }
}
