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
    [Authorize]
    public class AdministratorController : BaseController
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AdministratorController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
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
                    return RedirectToAction("Index", "Home");
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
    }
}
