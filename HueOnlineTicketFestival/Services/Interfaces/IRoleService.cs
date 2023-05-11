using HueOnlineTicketFestival.Models;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int id);
    Task<int> AddRoleAsync(Role Role);
    Task UpdateRoleAsync(int id, Role Role);
    Task DeleteRoleAsync(int id);
}
