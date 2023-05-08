using HueOnlineTicketFestival.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


[ApiController]
[Route("api/Locations")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _LocationService;
    private readonly ILogger<LocationController> _logger;


    public LocationController(ILocationService LocationService, ILogger<LocationController> logger)
    {
        _LocationService = LocationService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocations()
    {
        _logger.LogInformation("get");
        try
        {
            var locations = await _LocationService.GetAllLocationsAsync();
            return locations == null ? BadRequest() : Ok(locations);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocationById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var location = await _LocationService.GetLocationByIdAsync(id);
            return location == null ? NotFound() : Ok(location);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddLocation(Location location)
    {
        _logger.LogInformation("Creating a new Location");

        try
        {
            await _LocationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = location.LocationId }, location);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] Location location)
    {

        _logger.LogInformation("update a Location");

        if (id != location.LocationId)
        {
            return NotFound();
        }

        try
        {
            await _LocationService.UpdateLocationAsync(id, location);
            return CreatedAtAction(nameof(GetLocationById), new { id = location.LocationId }, location);
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        await _LocationService.DeleteLocationAsync(id);
        return NoContent();
    }
}
