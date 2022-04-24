using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBugTracker.Models;

namespace TheBugTracker.Services.Interfaces
{
    public interface IBTRolesService
    {
        public Task<List<IdentityRole>> GetRolesAsync();
        public Task<bool> IsUserInRoleAsync(BTUser user, string roleName);

        public Task<IEnumerable<string>> GetUserRolesAsync(BTUser user);  // returns a list of strings

        public Task<bool> AddUserToRoleAsync(BTUser user, string roleName);

        public Task<bool> RemoveUserFromRoleAsync(BTUser user, string roleName);

        public Task<bool> RemoveUserFromRolesAsync(BTUser user, IEnumerable<string> roles);



        public Task<List<BTUser>> GetUsersInRolesAsync(string rolename, int companyId);
        public Task<List<BTUser>> GetUsersNotInRole(string rolename, int companyId);


        public Task<string> GetRoleNameById(string roleId);
    }
}
