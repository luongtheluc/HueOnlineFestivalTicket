using HueOnlineTicketFestival.Models;

public interface IEventTypeService
{
    Task<IEnumerable<EventType>> GetAllEventTypesAsync();
    Task<EventType> GetEventTypeByIdAsync(int id);
    Task<int> AddEventTypeAsync(EventType EventType);
    Task UpdateEventTypeAsync(int id, EventType EventType);
    Task DeleteEventTypeAsync(int id);
}
