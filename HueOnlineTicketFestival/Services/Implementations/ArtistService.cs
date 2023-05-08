using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class ArtistService : IArtistService
{
    private readonly FestivalTicketContext _context;
    public ArtistService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddArtistAsync(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
        return artist.ArtistId;
    }

    public async Task DeleteArtistAsync(int id)
    {
        var artist = _context.Artists!.SingleOrDefault(b => b.ArtistId == id);
        if (artist != null)
        {
            _context.Artists!.Remove(artist);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
    {
        var Artists = await _context.Artists!.ToListAsync();
        return Artists;
    }

    public async Task<Artist> GetArtistByIdAsync(int id)
    {
        var artist = await _context.Artists!.FindAsync(id);
        return artist == null ? null : artist;
    }

    public async Task UpdateArtistAsync(int id, Artist artist)
    {
        if (id == artist.ArtistId)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }
    }
}
