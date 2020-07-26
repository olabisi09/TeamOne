using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberProject.Data;
using CyberProject.Entities;
using CyberProject.Enums;
using CyberProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyberProject.Controllers
{
    public class SalaryController : BaseController
    {
        // GET: /<controller>/
        private readonly IUser _user;
        public CyberProjectDataContext _context;
        private readonly ISalary _salary;

        public SalaryController(IUser user, CyberProjectDataContext context, ISalary salary)
        {
            _user = user;
            _context = context;
            _salary = salary;
        }

        [HttpGet]
        public async Task<IActionResult> ListSalaries()
        {
            var model = await _user.GetAll();

            if (model != null)
                return View(model);
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var us = await _user.GetAll();
            var g = await _user.GetAll();
            var userList = us.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.FirstName + " " + u.LastName
            });
            var gradeList = g.Select(u => new SelectListItem()
            {
                Value = u.Grade,
                Text = u.Grade
            });

            ViewBag.g = gradeList;
            ViewBag.us = userList;
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(User user)
        //{
        //    //var getUser = await _user.GetById(user.Id);
        //    //if (getUser != null)
        //    //{
        //    //    Salary s = new Salary()
        //    //    {
        //    //        //Sal = _salary.GetNetSalary()
        //    //    }
        //    //}
        //}
    }
}
