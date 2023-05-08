using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class LocationService : ILocationService
{
    private readonly FestivalTicketContext _context;
    public LocationService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddLocationAsync(Location Location)
    {
        _context.Locations.Add(Location);
        await _context.SaveChangesAsync();
        return Location.LocationId;
    }

    public async Task DeleteLocationAsync(int id)
    {
        var deleteBook = _context.Locations!.SingleOrDefault(b => b.LocationId == id);
        if (deleteBook != null)
        {
            _context.Locations!.Remove(deleteBook);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync()
    {
        var Locations = await _context.Locations!.ToListAsync();
        return Locations;
    }

    public async Task<Location> GetLocationByIdAsync(int id)
    {
        var Location = await _context.Locations!.FindAsync(id);
        return Location == null ? null : Location;
    }

    public async Task UpdateLocationAsync(int id, Location Location)
    {
        if (id == Location.LocationId)
        {
            _context.Locations.Update(Location);
            await _context.SaveChangesAsync();
        }
    }
}
