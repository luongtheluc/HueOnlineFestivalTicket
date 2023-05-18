using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;
using HueOnlineTicketFestival.data;
using HueOnlineTicketFestival.Prototypes;

public class UserService : IUserService
{
    private readonly FestivalTicketContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserService(FestivalTicketContext context, IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
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
        if (await _context.Users.CountAsync(x => x.Email == user.Email) > 0)
        {
            return -1;
        }
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

    public async Task<int> VerifyEmail(string token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);

        if (user == null)
        {
            return -1;
        }
        user.VerifyAt = DateTime.Now;
        try
        {
            await _context.SaveChangesAsync();
            return 1;
        }
        catch (System.Exception)
        {
            return -1;
        }

    }

    public async Task<int> ForgotPassword(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return -1;
        }

        user.PasswordResetToken = jwtHandler.CreateRandomToken();
        user.ResetTokenExpries = DateTime.Now.AddDays(1);
        await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<int> ResetPassword(string token, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == token);
        if (user == null || user.ResetTokenExpries < DateTime.Now)
        {
            return -1;
        }
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        user.Password = passwordHash;
        user.PasswordResetToken = null;
        user.ResetTokenExpries = null;

        await _context.SaveChangesAsync();
        return 1;
    }
}
