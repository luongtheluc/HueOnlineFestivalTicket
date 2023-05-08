using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;

[ApiController]
[Route("api/EventPictures")]
public class EventPictureController : ControllerBase
{
    private readonly IEventPictureService _EventPictureService;
    private readonly ILogger<EventPictureController> _logger;


    public EventPictureController(IEventPictureService EventPictureService, ILogger<EventPictureController> logger)
    {
        _EventPictureService = EventPictureService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEventPictures()
    {
        _logger.LogInformation("get");
        try
        {
            var eventPictures = await _EventPictureService.GetAllEventPicturesAsync();
            return eventPictures == null ? BadRequest() : Ok(eventPictures);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventPictureById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var eventPicture = await _EventPictureService.GetEventPictureByIdAsync(id);
            return eventPicture == null ? NotFound() : Ok(eventPicture);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddEventPicture(EventPicture eventPicture)
    {
        _logger.LogInformation("Creating a new EventPicture");

        try
        {
            await _EventPictureService.AddEventPictureAsync(eventPicture);
            return CreatedAtAction(nameof(GetEventPictureById), new { id = eventPicture.EventImageId }, eventPicture);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEventPicture(int id, [FromBody] EventPicture eventPicture)
    {

        _logger.LogInformation("update a EventPicture");

        if (id != eventPicture.EventImageId)
        {
            return NotFound();
        }

        try
        {
            await _EventPictureService.UpdateEventPictureAsync(id, eventPicture);
            return CreatedAtAction(nameof(GetEventPictureById), new { id = eventPicture.EventImageId }, eventPicture);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventPicture(int id)
    {
        await _EventPictureService.DeleteEventPictureAsync(id);
        return NoContent();
    }
}
