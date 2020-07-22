using CyberProject.Entities;
using CyberProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministratorController : BaseController
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdministratorController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    Alert("Role created", Enums.NotificationType.success);
                    return RedirectToAction("ListRoles", "Administrator");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            //if (role == null)
            //{
            //    return RedirectToAction("ListRoles", "Administrator");
            //}

            //var model = new EditRoleModel
            //{
            //    RoleName = role.Name
            //};
            return View(role);
        }

        //[HttpPost]
        //public async Task<IActionResult> EditRole(ApplicationRole model)
        //{
        //    var role = await _roleManager.FindByIdAsync(model.Id);

        //    if (role == null)
        //    {
        //        return RedirectToAction("ListRoles", "Administrator");
        //    }
        //    else
        //    {
        //        role.Name = model.RoleName;
        //        var result = await _roleManager.UpdateAsync(role);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("ListRoles", "Administrator");
        //        }
        //    }
        //    return View(model);

        //}
    }
}
