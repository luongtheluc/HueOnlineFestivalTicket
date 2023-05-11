using HueOnlineTicketFestival.Models;

public interface INewsService
{
    Task<IEnumerable<News>> GetAllNewsAsync();
    Task<News> GetNewsByIdAsync(int id);
    Task<int> AddNewsAsync(News News);
    Task UpdateNewsAsync(int id, News News);
    Task DeleteNewsAsync(int id);
}
