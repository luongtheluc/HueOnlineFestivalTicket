using HueOnlineTicketFestival.Models;

public interface ILocationService
{
    Task<IEnumerable<Location>> GetAllLocationsAsync();
    Task<Location> GetLocationByIdAsync(int id);
    Task<int> AddLocationAsync(Location Location);
    Task UpdateLocationAsync(int id, Location Location);
    Task DeleteLocationAsync(int id);
}
