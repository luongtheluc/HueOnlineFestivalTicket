using HueOnlineTicketFestival.data;
using HueOnlineTicketFestival.Models;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEventsAsync();
    Task<Event> GetEventByIdAsync(int id);
    Task<int> AddEventAsync(EventRequest Event);
    Task UpdateEventAsync(int id, Event Event);
    Task DeleteEventAsync(int id);
}
