using identityWebapiauthentication.Model;

namespace identityWebapiauthentication.Services
{
    public interface IRoleServices
    {
        Task<List<RoleModel>> GetRolesAsync();
        Task<List<string>> GetUserRolesAsync(string emailId);
        Task<List<string>> AddRolesAsync(string[] roles);
        Task<bool> AddUserRoleAsync(string userEmail, string[] roles);
    }
}
