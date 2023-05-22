using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class TicketService : ITicketService
{
    private readonly FestivalTicketContext _context;
    public TicketService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddTicketAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket.TicketId!;
    }

    public async Task DeleteTicketAsync(int id)
    {
        var delete = _context.Tickets!.SingleOrDefault(b => b.TicketId == id);
        if (delete != null)
        {
            _context.Tickets!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        var tickets = await _context.Tickets!.ToListAsync();
        return tickets;
    }

    public async Task<Ticket> GetTicketByIdAsync(int id)
    {
        var ticket = await _context.Tickets!.FindAsync(id);
        return ticket == null ? null : ticket;
    }

    public async Task UpdateTicketAsync(int id, Ticket ticket)
    {
        if (id == ticket.TicketId)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
