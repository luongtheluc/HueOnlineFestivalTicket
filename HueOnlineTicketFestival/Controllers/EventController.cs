using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;
using HueOnlineTicketFestival.data;

[ApiController]
[Route("api/Events")]
public class EventController : ControllerBase
{
    private readonly IEventService _EventService;
    private readonly ILogger<EventController> _logger;
    const string NAMEOFCONTROLLER = "Event";

    public EventController(IEventService EventService, ILogger<EventController> logger)
    {
        _EventService = EventService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        _logger.LogInformation("get");
        try
        {
            var events = await _EventService.GetAllEventsAsync();
            return events == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Đã xảy ra lỗi",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = events,
                Message = "Lấy ra tất cả " + NAMEOFCONTROLLER + " thành công",
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
    public async Task<IActionResult> GetEventById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var events = await _EventService.GetEventByIdAsync(id);
            return events == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "" + NAMEOFCONTROLLER + " này không tồn tại",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = events,
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
    public async Task<IActionResult> AddEvent(EventRequest events)
    {
        _logger.LogInformation("Creating a new Event");

        try
        {
            var id = await _EventService.AddEventAsync(events);
            var result = _EventService.GetEventByIdAsync(id);
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
    public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event events)
    {

        _logger.LogInformation("update a Event");

        if (id != events.EventId)
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
            await _EventService.UpdateEventAsync(id, events);
            var result = CreatedAtAction(nameof(GetEventById), new { id = events.EventId }, events);
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
    public async Task<IActionResult> DeleteEvent(int id)
    {
        await _EventService.DeleteEventAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Delete success",
            Success = true,
        });

    }
}
