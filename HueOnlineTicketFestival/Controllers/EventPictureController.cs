using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using HueOnlineTicketFestival.Prototypes;
using HueOnlineTicketFestival.data;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/EventPictures")]
public class EventPictureController : ControllerBase
{
    private readonly IEventPictureService _EventPictureService;
    private readonly ILogger<EventPictureController> _logger;

    private readonly IWebHostEnvironment _webHostEnvironment;

    public EventPictureController(IEventPictureService EventPictureService, ILogger<EventPictureController> logger, IWebHostEnvironment webHostEnvironment)
    {
        this._webHostEnvironment = webHostEnvironment;
        _EventPictureService = EventPictureService;
        _logger = logger;
    }
    [HttpGet("get-image-by-id"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetImageById(int id)
    {
        var images = await _EventPictureService.GetEventPictureByIdAsync(id);
        var image = System.IO.File.OpenRead(_webHostEnvironment.WebRootPath + "\\Images\\" + images.EventImageName);
        return File(image, "image/jpeg");
    }
    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllEventPictures()
    {
        _logger.LogInformation("get");
        try
        {
            var eventPictures = await _EventPictureService.GetAllEventPicturesAsync();
            if (eventPictures != null && eventPictures.Count() > 0)
            {

                foreach (var item in eventPictures)
                {
                    item.EventImageName = "http://localhost:5017/api/EventPictures/get-image-by-id?id=" + item.EventImageId;
                }
            }
            return eventPictures == null ? BadRequest() : Ok(eventPictures);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}"), Authorize(Roles = "Admin")]
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

    [HttpPost, Authorize(Roles = "Admin")]
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

    [HttpPut("{id}"), Authorize(Roles = "Admin")]
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

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteEventPicture(int id)
    {
        await _EventPictureService.DeleteEventPictureAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Success",
            Success = true
        });
    }
    [HttpPost("upload"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Upload([FromForm] UploadFile obj)
    {
        if (obj.Files!.Length > 0)
        {
            try
            {
                if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                }
                Guid id = Guid.NewGuid();
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + id + obj.Files.FileName))
                {
                    obj.Files.CopyTo(fileStream);
                    await fileStream.FlushAsync();
                    var eventPicture = new EventPicture
                    {
                        EventImageName = id + obj.Files.FileName,
                    };
                    await _EventPictureService.AddEventPictureAsync(eventPicture);
                    return Ok(new ApiResponse
                    {
                        Data = "\\Images\\" + obj.Files.FileName,
                        Message = "upload success",
                        Success = true
                    });
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest(new ApiResponse
                {
                    Data = null,
                    Message = ex.ToString(),
                    Success = false
                });
            }
        }
        else
        {
            return BadRequest(new ApiResponse
            {
                Data = null,
                Message = "upload fail",
                Success = false
            });
        }
    }


}
