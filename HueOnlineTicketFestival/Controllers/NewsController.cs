using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HueOnlineTicketFestival.Models;
using Microsoft.Bot.Connector;
using HueOnlineTicketFestival.Prototypes;
using Microsoft.AspNetCore.Authorization;
using HueOnlineTicketFestival.data;

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

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddNews(NewsRequest news)
    {
        if (news is null)
        {
            return BadRequest();
        }

        _logger.LogInformation("Creating a new News");

        try
        {
            var newNews = new News
            {
                NewName = news.NewName,
                EventId = news.EventId,
                NewsContent = news.NewsContent,
                CreateAt = DateTime.Now,

            };
            await _newsService.AddNewsAsync(newNews);
            var result = CreatedAtAction(nameof(GetNewsById), new { id = newNews.NewsId }, newNews);
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

    [HttpPut("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateNews(int id, [FromBody] NewsRequest news)
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
            var newNews = new News
            {
                NewName = news.NewName,
                EventId = news.EventId,
                NewsContent = news.NewsContent,
                UpdateAt = DateTime.Now,

            };
            await _newsService.UpdateNewsAsync(id, newNews);
            var result = CreatedAtAction(nameof(GetNewsById), new { id = newNews.NewsId }, newNews);
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

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
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
