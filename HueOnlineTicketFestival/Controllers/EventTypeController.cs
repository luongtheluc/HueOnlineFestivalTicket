using HueOnlineTicketFestival.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


[ApiController]
[Route("api/EventTypes")]
public class EventTypeController : ControllerBase
{
    private readonly IEventTypeService _eventTypeService;
    private readonly ILogger<EventTypeController> _logger;


    public EventTypeController(IEventTypeService eventTypeService, ILogger<EventTypeController> logger)
    {
        _eventTypeService = eventTypeService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEventTypes()
    {
        _logger.LogInformation("get");
        try
        {
            var eventTypes = await _eventTypeService.GetAllEventTypesAsync();
            return eventTypes == null ? BadRequest() : Ok(eventTypes);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventTypeById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var eventType = await _eventTypeService.GetEventTypeByIdAsync(id);
            return eventType == null ? NotFound() : Ok(eventType);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddEventType(EventType eventType)
    {
        _logger.LogInformation("Creating a new EventType");

        try
        {
            await _eventTypeService.AddEventTypeAsync(eventType);
            return CreatedAtAction(nameof(GetEventTypeById), new { id = eventType.EventTypeId }, eventType);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEventType(int id, [FromBody] EventType eventType)
    {

        _logger.LogInformation("update a EventType");

        if (id != eventType.EventTypeId)
        {
            return NotFound();
        }

        try
        {
            await _eventTypeService.UpdateEventTypeAsync(id, eventType);
            return CreatedAtAction(nameof(GetEventTypeById), new { id = eventType.EventTypeId }, eventType);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventType(int id)
    {
        await _eventTypeService.DeleteEventTypeAsync(id);
        return NoContent();
    }
}
