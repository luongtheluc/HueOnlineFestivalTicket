using HueOnlineTicketFestival.Models;
public interface IPermissionService
{
    Task<IEnumerable<Permission>> GetAllPermissionsAsync();
    Task<Permission> GetPermissionByIdAsync(int id);
    Task<int> AddPermissionAsync(Permission permission);
    Task UpdatePermissionAsync(int id, Permission permission);
    Task DeletePermissionAsync(int id);
}
