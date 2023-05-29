using System.Net;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;
using HueOnlineTicketFestival.data;
using HueOnlineTicketFestival.Prototypes;
using HueOnlineTicketFestival.Services.Interfaces;
using System.Web;

public class UserService : IUserService
{
    private readonly FestivalTicketContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IEmailService _emailService;
    public UserService(FestivalTicketContext context, IHttpContextAccessor httpContextAccessor, IEmailService emailService)
    {
        this._emailService = emailService;
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
        return result;

    }

    public async Task<User> GetUserByUsernamePasswordAsync(string username, string password)
    {
        var user = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        if (user != null)
        {
            var verify = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (verify)
            {
                return user;
            }
        }
        return user;
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

        var sendEmail = new EmailDTO
        {
            To = email,
            Subject = "Reset password link",
            Body = "<a target=" + "_blank" + " href=" + "http://localhost:5017/reset-password/" + user.PasswordResetToken + ">CLICK HERE</a>"

        };
        await _emailService.SendEmailAsync(sendEmail);
        return 1;
    }

    public async Task<int> ResetPassword(string token, string password)
    {
        // var u = await _context.Users.FirstOrDefaultAsync(u => u.Username == "theluc123");
        var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == token);
        if (user == null || user.ResetTokenExpries < DateTime.Now)
        {
            return -1;
        }
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        user.Password = passwordHash;
        user.PasswordResetToken = "0";
        user.ResetTokenExpries = null;
        await UpdateUserAsync(user.UserId, user);
        await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<int> CheckRefreshToken(string token)
    {
        if (await _context.Users.CountAsync(u => u.RefreshToken == token) > 0)
        {
            var user = await _context.Users.Where(p => p.RefreshToken == token).FirstOrDefaultAsync();
            if (user!.RefreshTokenExpries > DateTime.Now)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return -1;
        }
    }

    public async Task<User> GetUserByRefreshToken(string token)
    {
        var user = await _context.Users.Where(u => u.RefreshToken == token).FirstOrDefaultAsync();
        return user!;
    }
}
