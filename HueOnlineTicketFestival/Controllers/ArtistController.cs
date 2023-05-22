using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;
using Microsoft.AspNetCore.Authorization;

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

    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllArtists()
    {
        _logger.LogInformation("get");
        try
        {
            var Artists = await _ArtistService.GetAllArtistsAsync();
            return Artists == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Đã xảy ra lỗi",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = Artists,
                Message = "lấy ra tất cả nghệ sĩ thành công",
                Success = true
            });
        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest(new ApiResponse
            {
                Data = null,
                Message = "lấy ra tất cả nghệ sĩ thật bại",
                Success = false
            });
        }
    }

    [HttpGet("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetArtistById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var Artist = await _ArtistService.GetArtistByIdAsync(id);
            return Artist == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Nghệ sĩ này không tồn tại",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = Artist,
                Message = "lấy ra nghệ sĩ thành công",
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
    public async Task<IActionResult> AddArtist(Artist Artist)
    {
        _logger.LogInformation("Creating a new Artist");

        try
        {
            await _ArtistService.AddArtistAsync(Artist);
            var result = CreatedAtAction(nameof(GetArtistById), new { id = Artist.ArtistId }, Artist);
            return Ok(new ApiResponse
            {
                Data = result,
                Message = "Thêm mới nghệ sĩ thành công",
                Success = true
            });
        }
        catch (System.Exception)
        {

            return BadRequest(new ApiResponse
            {
                Data = null,
                Message = "Thêm mới nghệ sĩ thất bại",
                Success = false
            });
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArtist(int id, [FromBody] Artist Artist)
    {

        _logger.LogInformation("update a Artist");

        if (id != Artist.ArtistId)
        {
            return NotFound(new ApiResponse
            {
                Data = null,
                Message = "Không tìm thấy nghệ sĩ",
                Success = false,
            });
        }
        try
        {
            await _ArtistService.UpdateArtistAsync(id, Artist);
            var result = CreatedAtAction(nameof(GetArtistById), new { id = Artist.ArtistId }, Artist);
            return Ok(new ApiResponse
            {
                Data = result,
                Success = true,
                Message = "Update nghệ sĩ thành công"
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
    public async Task<IActionResult> DeleteArtist(int id)
    {
        await _ArtistService.DeleteArtistAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Delete success",
            Success = true,
        });

    }
}
