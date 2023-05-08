using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class UserService : IUserService
{
    private readonly FestivalTicketContext _context;
    public UserService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddUserAsync(User user)
    {
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
}
