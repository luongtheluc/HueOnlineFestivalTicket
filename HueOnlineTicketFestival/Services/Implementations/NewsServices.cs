using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class Newservice : INewsService
{
    private readonly FestivalTicketContext _context;
    public Newservice(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddNewsAsync(News news)
    {
        _context.News.Add(news);
        await _context.SaveChangesAsync();
        return news.NewsId;
    }

    public async Task DeleteNewsAsync(int id)
    {
        var delete = _context.News!.SingleOrDefault(b => b.NewsId == id);
        if (delete != null)
        {
            _context.News!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<News>> GetAllNewsAsync()
    {
        var news = await _context.News!.ToListAsync();
        return news;
    }

    public async Task<News> GetNewsByIdAsync(int id)
    {
        var news = await _context.News!.FindAsync(id);
        return news;
    }

    public async Task UpdateNewsAsync(int id, News news)
    {
        if (id == news.NewsId)
        {
            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }
    }
}
