using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CyberProject.Data;
using CyberProject.Entities;
using CyberProject.Enums;
using CyberProject.Interfaces;
using CyberProject.Models;
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
        private readonly IGrade _grade;

        public SalaryController(IUser user, CyberProjectDataContext context, ISalary salary, IGrade grade)
        {
            _user = user;
            _context = context;
            _salary = salary;
            _grade = grade;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _salary.GetAll();

            if (model != null)
                return View(model);
            return View();
        }

        public async Task<ViewResult> Details(int Id)
        {
            Salary salary = await _salary.GetById(Id);
            ViewData["Title"] = "Salary Breakdown";
            ViewData["Salary Preview"] = salary;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Preview()
        {
            var grade = await _grade.GetAll();
            var user = await _user.GetAll();
            var gradeList = grade.Select(g => new SelectListItem()
            {
                Value = g.GradeID.ToString(),
                Text = g.GradeName
            });
            var userList = user.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.FirstName + " " + u.LastName
            });

            ViewBag.grade = gradeList;
            ViewBag.user = userList;

            return View();
        }

        [HttpPost]
        public IActionResult Preview(Salary salary)
        {
            float percentOne = 5;
            float percentTwo = 3;

            if (salary.GradeId == 1)
            {
                //salary.Amount = 500000;

                salary.TaxPercentage = 5;
                salary.Tax = salary.Amount * (salary.TaxPercentage / 100);
                salary.TaxPayType = "Deduction";

                salary.Housing = (percentOne / 100) * salary.Amount;
                salary.HousingPayType = "Allowance";

                salary.Medical = salary.Amount * (percentOne / 100);
                salary.MedicalPayType = "Allowance";

                salary.Lunch = salary.Amount * (percentOne / 100);
                salary.LunchPayType = "Allowance";

                salary.Transport = salary.Amount * (percentOne / 100);
                salary.TransportPayType = "Allowance";


            }

            if (salary.GradeId == 2)
            {
                //salary.Amount = 100000;

                salary.TaxPercentage = 3;
                salary.Tax = salary.Amount * (salary.TaxPercentage / 100);
                salary.TaxPayType = "Deduction";

                salary.Housing = (percentTwo / 100) * salary.Amount;
                salary.HousingPayType = "Allowance";

                salary.Medical = salary.Amount * (percentTwo / 100);
                salary.MedicalPayType = "Allowance";

                salary.Lunch = salary.Amount * (percentTwo / 100);
                salary.LunchPayType = "Allowance";

                salary.Transport = salary.Amount * (percentTwo / 100);
                salary.TransportPayType = "Allowance";


            }
            salary.NetSalary = (salary.Amount - salary.Tax) + salary.Housing + salary.Medical + salary.Lunch + salary.Transport;

            return View(salary);
        }

        [HttpGet]
        public async Task<IActionResult> ComputeSalary()
        {
            var grade = await _grade.GetAll();
            var user = await _user.GetAll();
            var gradeList = grade.Select(g => new SelectListItem()
            {
                Value = g.GradeID.ToString(),
                Text = g.GradeName
            });
            var userList = user.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.FirstName + " " + u.LastName
            });

            ViewBag.grade = gradeList;
            ViewBag.user = userList;
            return View(new Salary());
        }

        [HttpPost]
        public async Task<IActionResult> ComputeSalary(Salary salary)
        {
            var createSalary = await _salary.AddAsync(salary);

            if (createSalary)
            {
                Alert("Salary created successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Salary not created!", NotificationType.error);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var editSalary = await _salary.GetById(id);

            if (editSalary == null)
            {
                return RedirectToAction("Index");
            }

            var grade = await _user.GetAll();
            var user = await _user.GetAll();
            var gradeList = grade.Select(g => new SelectListItem()
            {
                Value = g.gradeID.ToString(),
                Text = g.Grade.GradeName
            });
            var userList = user.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.FirstName + " " + u.LastName
            });

            ViewBag.grade = gradeList;
            ViewBag.user = userList;
            return View(editSalary);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Salary salary)
        {
            //_salary.GetSalary(salary);
            var editSalary = await _salary.Update(salary);

            if (editSalary)
            {
                Alert("Salary details edited successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Salary details not edited", NotificationType.error);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletesalary = await _salary.Delete(id);
            if (deletesalary)
            {
                Alert("Salary deleted successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Salary not deleted", NotificationType.error);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
