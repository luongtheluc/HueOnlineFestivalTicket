using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;
using HueOnlineTicketFestival.data;

public class UserService : IUserService
{
    private readonly FestivalTicketContext _context;
    public UserService(FestivalTicketContext context)
    {
        this._context = context;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public async Task<int> AddUserAsync(User user)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = passwordHash;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.UserId;
    }



    public async Task DeleteUserAsync(int id)
    {
        var deleteuser = _context.Users!.SingleOrDefault(b => b.UserId == id);
        if (deleteuser != null)
        {
            _context.Users!.Remove(deleteuser);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var Users = await _context.Users!.ToListAsync();
        return Users;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _context.Users!.FindAsync(id);
        return user == null ? null : user;
    }


    public async Task UpdateUserAsync(int id, User user)
    {
        if (id == user.UserId)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> CheckUserName(string userName)
    {

        var result = await _context.Users.CountAsync(x => x.Username == userName) > 0;
        Console.WriteLine(result);
        return result;

    }

    public async Task<User> GetUserByUsernamePasswordAsync(string username, string password)
    {
        var user = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        var verify = BCrypt.Net.BCrypt.Verify(password, user.Password);
        return verify ? user : null;
    }
}
