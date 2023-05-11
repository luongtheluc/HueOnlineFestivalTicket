using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;

[ApiController]
[Route("api/News")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;
    private readonly ILogger<NewsController> _logger;
    const string NAMEOFCONTROLLER = "Tin tức"; //tin tuc

    public NewsController(INewsService newsService, ILogger<NewsController> logger)
    {
        _newsService = newsService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNewss()
    {
        _logger.LogInformation("get");
        try
        {
            var news = await _newsService.GetAllNewsAsync();
            return news == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "Đã xảy ra lỗi",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = news,
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
    public async Task<IActionResult> GetNewsById(int id)
    {
        _logger.LogInformation("get ");
        try
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            return news == null ? NotFound(new ApiResponse
            {
                Data = null,
                Message = "" + NAMEOFCONTROLLER + " này không tồn tại",
                Success = false
            }) : Ok(new ApiResponse
            {
                Data = news,
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
    public async Task<IActionResult> AddNews(News news)
    {
        _logger.LogInformation("Creating a new News");

        try
        {
            await _newsService.AddNewsAsync(news);
            var result = CreatedAtAction(nameof(GetNewsById), new { id = news.NewsId }, news);
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
    public async Task<IActionResult> UpdateNews(int id, [FromBody] News news)
    {

        _logger.LogInformation("update a News");

        if (id != news.NewsId)
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
            await _newsService.UpdateNewsAsync(id, news);
            var result = CreatedAtAction(nameof(GetNewsById), new { id = news.NewsId }, news);
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
    public async Task<IActionResult> DeleteNews(int id)
    {
        await _newsService.DeleteNewsAsync(id);
        return Ok(new ApiResponse
        {
            Data = null,
            Message = "Delete success",
            Success = true,
        });

    }
}
