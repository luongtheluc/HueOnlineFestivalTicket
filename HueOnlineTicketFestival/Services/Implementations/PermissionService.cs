using Microsoft.EntityFrameworkCore;
using HueOnlineTicketFestival.Models;

public class PermissionService : IPermissionService
{
    private readonly FestivalTicketContext _context;
    public PermissionService(FestivalTicketContext context)
    {
        this._context = context;
    }

    public async Task<int> AddPermissionAsync(Permission permission)
    {
        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();
        return permission.PermissionId;
    }

    public async Task DeletePermissionAsync(int id)
    {
        var delete = _context.Permissions!.SingleOrDefault(b => b.PermissionId == id);
        if (delete != null)
        {
            _context.Permissions!.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
    {
        var Permissions = await _context.Permissions!.ToListAsync();
        return Permissions;
    }

    public async Task<Permission> GetPermissionByIdAsync(int id)
    {
        var getById = await _context.Permissions!.FindAsync(id);
        return getById == null ? null : getById;
    }

    public async Task UpdatePermissionAsync(int id, Permission permission)
    {
        if (id == permission.PermissionId)
        {
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
        }
    }
}
