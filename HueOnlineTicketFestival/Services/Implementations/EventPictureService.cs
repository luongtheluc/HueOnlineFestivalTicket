using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class EventPictureService : IEventPictureService
{
    private readonly FestivalTicketContext _context;
    public EventPictureService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddEventPictureAsync(EventPicture EventPicture)
    {
        _context.EventPictures.Add(EventPicture);
        await _context.SaveChangesAsync();
        return EventPicture.EventImageId;
    }

    public async Task DeleteEventPictureAsync(int id)
    {
        var deleteEventImageId = _context.EventPictures!.SingleOrDefault(b => b.EventImageId == id);
        if (deleteEventImageId != null)
        {
            _context.EventPictures!.Remove(deleteEventImageId);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<EventPicture>> GetAllEventPicturesAsync()
    {
        var EventPictures = await _context.EventPictures!.ToListAsync();
        return EventPictures;
    }

    public async Task<EventPicture> GetEventPictureByIdAsync(int id)
    {
        var EventPicture = await _context.EventPictures!.FindAsync(id);
        return EventPicture == null ? null : EventPicture;
    }

    public async Task UpdateEventPictureAsync(int id, EventPicture EventPicture)
    {
        if (id == EventPicture.EventImageId)
        {
            _context.EventPictures.Update(EventPicture);
            await _context.SaveChangesAsync();
        }
    }
}
