using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class RoleService : IRoleService
{
    private readonly FestivalTicketContext _context;
    public RoleService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddRoleAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role.RoleId;
    }

    public async Task DeleteRoleAsync(int id)
    {
        var delete = _context.Roles!.SingleOrDefault(b => b.RoleId == id);
        if (delete != null)
        {
            _context.Roles!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        var Roles = await _context.Roles!.ToListAsync();
        return Roles;
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        var getById = await _context.Roles!.FindAsync(id);
        return getById == null ? null : getById;
    }

    public async Task UpdateRoleAsync(int id, Role role)
    {
        if (id == role.RoleId)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
