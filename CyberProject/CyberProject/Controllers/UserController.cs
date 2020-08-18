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
        private IGrade _grade;
        private IUser _userService;
        private IConfiguration _config;

        public UserController(IUser userService, IConfiguration config, IAccount account, IFaculty faculty, IDepartment department, IGrade grade)
        {
            _account = account;
            _userService = userService;
            _config = config;
            _faculty = faculty;
            _grade = grade;
            _department = department;
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
            var grade = await _grade.GetAll();
            var level = await _grade.GetAll();
            var step = await _grade.GetAll();
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
            var gradeList = grade.Select(g => new SelectListItem()
            {
                Value = g.GradeID.ToString(),
                Text = g.GradeName
            });
            var levelList = level.Select(l => new SelectListItem()
            {
                Value = l.GradeID.ToString(),
                Text = l.Level
            });
            var stepList = step.Select(s => new SelectListItem()
            {
                Value = s.GradeID.ToString(),
                Text = s.Step
            });
            ViewBag.grade = gradeList;
            ViewBag.fac = facList;
            ViewBag.dept = deptList;
            ViewBag.level = levelList;
            ViewBag.step = stepList;
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

        public async Task<ViewResult> Details(int Id)
        {
            User user = await _userService.GetById(Id);
            ViewData["Title"] = "Salary Breakdown";
            ViewData["Salary Preview"] = user;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var editUser = await _userService.GetById(id);

            if (editUser == null)
            {
                return RedirectToAction("ListUsers");
            }
            var grade = await _grade.GetAll();
            var dept = await _department.GetAll();
            var gradeList = grade.Select(g => new SelectListItem()
            {
                Value = g.GradeID.ToString(),
                Text = g.GradeName
            });
            var deptList = dept.Select(d => new SelectListItem()
            {
                Value = d.deptID.ToString(),
                Text = d.deptName
            });
            ViewBag.grade = gradeList;
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
