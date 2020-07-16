using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CyberProject.Entities;
using CyberProject.Enums;
using CyberProject.Interfaces;
using CyberProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CyberProject.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccount _account;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<ApplicationRole> _roleManager;
        //string Message = "";

        //public AccountController(SignInManager<ApplicationUser> signInManager,
        //    RoleManager<ApplicationRole> roleManager,
        //    UserManager<ApplicationUser> userManager)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}


        public AccountController(IAccount account, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _account = account;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(ApplicationUser user, SignUpViewModel model)
        {
            var sign = await _account.CreateUser(user, model.Password);

            if (sign)
            {
                Alert("Account created successfully", NotificationType.success);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                Alert("Invalid username or password", NotificationType.error);
                ModelState.AddModelError("", "UserName/Password is incorrect");
                return View();
            }

            var signin = await _account.Login(login);

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