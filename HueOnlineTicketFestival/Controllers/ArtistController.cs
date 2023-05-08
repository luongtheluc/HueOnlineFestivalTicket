using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;

[ApiController]
[Route("api/Artists")]
public class ArtistController : ControllerBase
{
    private readonly IArtistService _ArtistService;
    private readonly ILogger<ArtistController> _logger;


    public ArtistController(IArtistService ArtistService, ILogger<ArtistController> logger)
    {
        _ArtistService = ArtistService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllArtists()
    {
        _logger.LogInformation("get");
        try
        {
            var Artists = await _ArtistService.GetAllArtistsAsync();
            return Artists == null ? BadRequest() : Ok(Artists);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArtistById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var Artist = await _ArtistService.GetArtistByIdAsync(id);
            return Artist == null ? NotFound() : Ok(Artist);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddArtist(Artist Artist)
    {
        _logger.LogInformation("Creating a new Artist");

        try
        {
            await _ArtistService.AddArtistAsync(Artist);
            return CreatedAtAction(nameof(GetArtistById), new { id = Artist.ArtistId }, Artist);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArtist(int id, [FromBody] Artist Artist)
    {

        _logger.LogInformation("update a Artist");

        if (id != Artist.ArtistId)
        {
            return NotFound();
        }

        try
        {
            await _ArtistService.UpdateArtistAsync(id, Artist);
            return CreatedAtAction(nameof(GetArtistById), new { id = Artist.ArtistId }, Artist);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtist(int id)
    {
        await _ArtistService.DeleteArtistAsync(id);
        return NoContent();
    }
}
