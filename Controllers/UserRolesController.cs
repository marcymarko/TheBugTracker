using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTracker.Data;
using TheBugTracker.Extensions;
using TheBugTracker.Models;
using TheBugTracker.Models.ViewModels;
using TheBugTracker.Services.Interfaces;

namespace TheBugTracker.Controllers
{
    [Authorize]
    public class UserRolesController : Controller
    {
        private readonly IBTRolesService _roleService;
        private readonly IBTCompanyInfoService _companyService;

        public UserRolesController(IBTRolesService roleService, IBTCompanyInfoService companyService)
        {
            _roleService = roleService;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles()
        {
            // Add an instance of the viewModel as a list
            List<ManageUserRolesViewModel> model = new();

            // get companyId
            int companyId = User.Identity.GetCompanyId().Value;

            // get sll company users
            List<BTUser> users = await _companyService.GetAllMembersAsync(companyId);


            // Loop over the users ton populate the viewModel
            // instantiate vieModel
            // use roleService
            // create multi selects
            foreach(BTUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.BTUser = user;
                IEnumerable<string> selected = await _roleService.GetUserRolesAsync(user);
                viewModel.Roles = new MultiSelectList(await _roleService.GetRolesAsync(), "Name", "Name", selected);

                model.Add(viewModel);
            }

            // return the model to the view
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel member)
        {
            // Get the company Id
            int companyId = User.Identity.GetCompanyId().Value;


            // Instantiate the BTUser
            BTUser btUser = (await _companyService.GetAllMembersAsync(companyId)).FirstOrDefault(u => u.Id == member.BTUser.Id);

            // Get the rolse for the user
            IEnumerable<string> roles = await _roleService.GetUserRolesAsync(btUser);

            // grab the selected role
            string userRole = member.SelectedRoles.FirstOrDefault();

            if (!string.IsNullOrEmpty(userRole))
            {
                // Remove user from the
                if(await _roleService.RemoveUserFromRolesAsync(btUser, roles))
                {
                    // Add user to the new role
                    await _roleService.AddUserToRoleAsync(btUser, userRole);
                }


            }

            // Navigate back to the view
            return RedirectToAction(nameof(ManageUserRoles));

        }
    }
}
