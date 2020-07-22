using CyberProject.Entities;
using CyberProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Controllers
{
    public class SalaryController : BaseController
    {
        private IUser _user;

        public SalaryController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult CalculateSalary()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateSalary(Salary s)
        {
            //var getUser = _user.GetById(Id);
            if (s.salary > 100000)
            {
                s.Tax = s.salary * (10 / 100);
            }
            else if (s.salary > 50000)
            {
                s.Tax = s.salary * (5 / 100);
            }
            else s.Tax = 0;

            s.NetSalary = s.salary - s.Tax;
            return View(s);
        }
    }
}
