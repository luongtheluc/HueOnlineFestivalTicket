
using HueOnlineTicketFestival.Models;

public interface ITicketCheckinService
{
    Task<IEnumerable<TicketCheckin>> GetAllTicketCheckinsAsync();
    Task<TicketCheckin> GetTicketCheckinByIdAsync(int id);
    Task<int> AddTicketCheckinAsync(TicketCheckin TicketCheckin);
    Task UpdateTicketCheckinAsync(int id, TicketCheckin TicketCheckin);
    Task DeleteTicketCheckinAsync(int id);
}
