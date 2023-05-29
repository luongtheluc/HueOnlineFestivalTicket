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
    Task<int> VerifyEmail(string token);
    Task<int> ForgotPassword(string email);
    Task<int> ResetPassword(string token, string password);
    Task<int> CheckRefreshToken(string token);
    Task<User> GetUserByRefreshToken(string token);
}
