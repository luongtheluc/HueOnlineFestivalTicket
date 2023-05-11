using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class TicketTypeService : ITicketTypeService
{
    private readonly FestivalTicketContext _context;
    public TicketTypeService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddTicketTypeAsync(TicketType ticketType)
    {
        _context.TicketTypes.Add(ticketType);
        await _context.SaveChangesAsync();
        return ticketType.TicketTypeId;
    }

    public async Task DeleteTicketTypeAsync(int id)
    {
        var delete = _context.TicketTypes!.SingleOrDefault(b => b.TicketTypeId == id);
        if (delete != null)
        {
            _context.TicketTypes!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TicketType>> GetAllTicketTypesAsync()
    {
        var ticketType = await _context.TicketTypes!.ToListAsync();
        return ticketType;
    }

    public async Task<TicketType> GetTicketTypeByIdAsync(int id)
    {
        var ticketType = await _context.TicketTypes!.FindAsync(id);
        return ticketType == null ? null : ticketType;
    }

    public async Task UpdateTicketTypeAsync(int id, TicketType ticketType)
    {
        if (id == ticketType.TicketTypeId)
        {
            _context.TicketTypes.Update(ticketType);
            await _context.SaveChangesAsync();
        }
    }
}
