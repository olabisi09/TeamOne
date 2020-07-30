using CyberProject.Data;
using CyberProject.Dtos;
using CyberProject.Entities;
using CyberProject.Enums;
using CyberProject.Interfaces;
using CyberProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CyberProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        private IAccount _account;
        private IFaculty _faculty;
        private IDepartment _department;
        private IUser _userService;
        private IConfiguration _config;
        private CyberProjectDataContext _context;

        public UserController(IUser userService, IConfiguration config, IAccount account, IFaculty faculty, IDepartment department, CyberProjectDataContext context)
        {
            _account = account;
            _userService = userService;
            _config = config;
            _faculty = faculty;
            _department = department;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserModel registerUser)
        {
            ApplicationUser user = new ApplicationUser();

            user.FirstName = registerUser.FirstName;
            user.LastName = registerUser.LastName;
            user.UserName = registerUser.Username;
            user.Email = registerUser.Email;
            user.PhoneNumber = registerUser.PhoneNo;

            var newUser = await _account.CreateUser(user, registerUser.Password);
            if (newUser)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var fac = await _faculty.GetAll();
            var dept = await _department.GetAll();
            var facList = fac.Select(f => new SelectListItem()
            {
                Value = f.facultyID.ToString(),
                Text = f.facultyName
            });
            var deptList = dept.Select(d => new SelectListItem()
            {
                Value = d.deptID.ToString(),
                Text = d.deptName
            });
            ViewBag.fac = facList;
            ViewBag.dept = deptList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var createUser = await _userService.AddAsync(user);
            if (createUser)
            {
                Alert("User created successfully.", NotificationType.success);
                return RedirectToAction("ListUsers", "User");
            }
            else
            {
                Alert("User not created!", NotificationType.error);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var model = await _userService.GetAll();

            if (model != null)
                return View(model);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ComputeSalary(int id)
        {
            var getUser = await _userService.GetById(id);

            if (getUser == null)
            {
                return RedirectToAction("ListUsers");
            }
            var fac = await _faculty.GetAll();
            var dept = await _department.GetAll();
            var facList = fac.Select(f => new SelectListItem()
            {
                Value = f.facultyID.ToString(),
                Text = f.facultyName
            });
            var deptList = dept.Select(d => new SelectListItem()
            {
                Value = d.deptID.ToString(),
                Text = d.deptName
            });
            ViewBag.fac = facList;
            ViewBag.dept = deptList;
            return View(getUser);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var editUser = await _userService.GetById(id);

            if (editUser == null)
            {
                return RedirectToAction("ListUsers");
            }
            var fac = await _faculty.GetAll();
            var dept = await _department.GetAll();
            var facList = fac.Select(f => new SelectListItem()
            {
                Value = f.facultyID.ToString(),
                Text = f.facultyName
            });
            var deptList = dept.Select(d => new SelectListItem()
            {
                Value = d.deptID.ToString(),
                Text = d.deptName
            });
            ViewBag.fac = facList;
            ViewBag.dept = deptList;
            return View(editUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            //var editUser = await _faculty.GetById(id);
            var editUser = await _userService.Update(user);

            if (editUser)
            {
                Alert("User edited successfully", NotificationType.success);
                return RedirectToAction("ListUsers");
            }
            else
            {
                Alert("User not edited", NotificationType.error);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteEmployee = await _userService.Delete(id);
            if (deleteEmployee)
            {
                Alert("Employee deleted successfully", NotificationType.success);
                return RedirectToAction("ListUsers", "User");
            }
            else
            {
                Alert("Employee not deleted", NotificationType.error);
            }
            return View();
        }
    }
}
