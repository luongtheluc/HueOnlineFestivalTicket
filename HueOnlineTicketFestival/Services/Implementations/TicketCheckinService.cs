using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class TicketCheckinService : ITicketCheckinService
{
    private readonly FestivalTicketContext _context;
    public TicketCheckinService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddTicketCheckinAsync(TicketCheckin ticketCheckin)
    {
        _context.TicketCheckins.Add(ticketCheckin);
        await _context.SaveChangesAsync();
        return ticketCheckin.TicketCheckinId;
    }

    public async Task DeleteTicketCheckinAsync(int id)
    {
        var delete = _context.TicketCheckins!.SingleOrDefault(b => b.TicketCheckinId == id);
        if (delete != null)
        {
            _context.TicketCheckins!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TicketCheckin>> GetAllTicketCheckinsAsync()
    {
        var TicketCheckins = await _context.TicketCheckins!.ToListAsync();
        return TicketCheckins;
    }

    public async Task<TicketCheckin> GetTicketCheckinByIdAsync(int id)
    {
        var ticketCheckin = await _context.TicketCheckins!.FindAsync(id);
        return ticketCheckin == null ? null : ticketCheckin;
    }

    public async Task UpdateTicketCheckinAsync(int id, TicketCheckin ticketCheckin)
    {
        if (id == ticketCheckin.TicketCheckinId)
        {
            _context.TicketCheckins.Update(ticketCheckin);
            await _context.SaveChangesAsync();
        }
    }
}
