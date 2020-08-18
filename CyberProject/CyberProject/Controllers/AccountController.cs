using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CyberProject.Dtos;
using CyberProject.Entities;
using CyberProject.Enums;
using CyberProject.Interfaces;
using CyberProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CyberProject.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccount _account;
        private readonly IGrade _grade;
        private readonly IUser _user;
        private readonly IDepartment _department;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAccount account, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IGrade grade, IUser user, IDepartment department)
        {
            _account = account;
            _signInManager = signInManager;
            _userManager = userManager;
            _grade = grade;
            _user = user;
            _department = department;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Profile()
        {
            var user = _userManager.GetUserId(User);
            if(user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ApplicationUser us = _userManager.FindByIdAsync(user).Result;
                return View(us);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Signup()
        {
            var grade = await _grade.GetAll();
            var gradeList = grade.Select(g => new SelectListItem()
            {
                Value = g.GradeID.ToString(),
                Text = g.GradeName
            });
            
            ViewBag.grade = gradeList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNo, Country = model.Country, State = model.State, LGA = model.LGA};
                var signUp = await _userManager.CreateAsync(user, model.Password);

                if (signUp.Succeeded)
                {
                    signUp = await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Alert("Invalid username or password", NotificationType.error);
                ModelState.AddModelError("", "UserName/Password is incorrect");
                return View();
            }

            var signin = await _account.Login(model);

            if (signin)
            {
                Alert("Welcome!", NotificationType.success);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");


        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}