using HueOnlineTicketFestival.Models;

public interface ITicketTypeService
{
    Task<IEnumerable<TicketType>> GetAllTicketTypesAsync();
    Task<TicketType> GetTicketTypeByIdAsync(int id);
    Task<int> AddTicketTypeAsync(TicketType ticketType);
    Task UpdateTicketTypeAsync(int id, TicketType ticketType);
    Task DeleteTicketTypeAsync(int id);
}
