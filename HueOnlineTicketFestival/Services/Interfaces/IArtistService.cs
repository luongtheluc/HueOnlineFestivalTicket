using HueOnlineTicketFestival.Models;

public interface IArtistService
{
    Task<IEnumerable<Artist>> GetAllArtistsAsync();
    Task<Artist> GetArtistByIdAsync(int id);
    Task<int> AddArtistAsync(Artist Artist);
    Task UpdateArtistAsync(int id, Artist Artist);
    Task DeleteArtistAsync(int id);
}
