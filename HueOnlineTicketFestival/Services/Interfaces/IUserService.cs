using HueOnlineTicketFestival.data;
using HueOnlineTicketFestival.Models;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<int> AddUserAsync(User user);
    Task UpdateUserAsync(int id, User user);
    Task DeleteUserAsync(int id);
    Task<bool> CheckUserName(string username);
    Task<User> GetUserByUsernamePasswordAsync(string username, string password);
}
