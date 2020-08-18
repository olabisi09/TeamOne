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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyberProject.Controllers
{
    public class GradeController : BaseController
    {
        private IGrade _grade;

        private readonly UserManager<ApplicationUser> _userManager;
        public GradeController(IGrade grade, UserManager<ApplicationUser> userManager)
        {
            _grade = grade;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _grade.GetAll();

            if (model != null)
                return View(model);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Grade grade)
        {
            //grade.CreatedBy = _userManager.GetUserName(User);
            var createGrade = await _grade.AddAsync(grade);

            //if (createGrade)
            //{
            //    return RedirectToAction("Index");
            //}

            if (createGrade)
            {
                Alert("Grade created successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Grade not created!", NotificationType.error);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var editGrade = await _grade.GetById(id);

            if (editGrade == null)
            {
                return RedirectToAction("Index");
            }
            return View(editGrade);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Grade grade)
        {
            //var editGrade = await _grade.GetById(id);
            var editGrade = await _grade.Update(grade, grade.GradeID);

            if (editGrade)
            {
                Alert("Grade edited successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Grade not edited", NotificationType.error);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteGrade = await _grade.Delete(id);
            if (deleteGrade)
            {
                Alert("Grade deleted successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Grade not deleted", NotificationType.error);
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
