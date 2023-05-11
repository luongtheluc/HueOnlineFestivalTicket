using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class EventService : IEventService
{
    private readonly FestivalTicketContext _context;
    public EventService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddEventAsync(Event events)
    {
        _context.Events.Add(events);
        await _context.SaveChangesAsync();
        return events.EventId;
    }


    public async Task DeleteEventAsync(int id)
    {
        var delete = _context.Events!.SingleOrDefault(b => b.EventId == id);
        if (delete != null)
        {
            _context.Events!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        var events = await _context.Events!.ToListAsync();
        return events;
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        var getById = await _context.Events!.FindAsync(id);
        return getById == null ? null : getById;
    }

    public async Task UpdateEventAsync(int id, Event events)
    {
        if (id == events.EventId)
        {
            _context.Events.Update(events);
            await _context.SaveChangesAsync();
        }
    }
}
