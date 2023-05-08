using HueOnlineTicketFestival.Models;

public interface ITicketService
{
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> GetTicketByIdAsync(int id);
    Task<int> AddTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(int id, Ticket ticket);
    Task DeleteTicketAsync(int id);
}
