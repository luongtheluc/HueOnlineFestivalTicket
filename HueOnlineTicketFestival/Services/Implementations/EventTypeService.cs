using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class EventTypeService : IEventTypeService
{
    private readonly FestivalTicketContext _context;
    public EventTypeService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddEventTypeAsync(EventType eventType)
    {
        _context.EventTypes.Add(eventType);
        await _context.SaveChangesAsync();
        return eventType.EventTypeId;
    }

    public async Task DeleteEventTypeAsync(int id)
    {
        var delete = _context.EventTypes!.SingleOrDefault(b => b.EventTypeId == id);
        if (delete != null)
        {
            _context.EventTypes!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<EventType>> GetAllEventTypesAsync()
    {
        var eventTypes = await _context.EventTypes!.ToListAsync();
        return eventTypes;
    }

    public async Task<EventType> GetEventTypeByIdAsync(int id)
    {
        var eventType = await _context.EventTypes!.FindAsync(id);
        if (eventType != null)
            return eventType;
        return null;
    }

    public async Task UpdateEventTypeAsync(int id, EventType eventType)
    {
        if (id == eventType.EventTypeId)
        {
            _context.EventTypes.Update(eventType);
            await _context.SaveChangesAsync();
        }
    }
}
