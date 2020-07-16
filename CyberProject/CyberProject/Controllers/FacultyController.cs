using CyberProject.Entities;
using CyberProject.Enums;
using CyberProject.Interfaces;
using CyberProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Controllers
{
    public class FacultyController : BaseController
    {
        private IFaculty _faculty;

        private readonly UserManager<ApplicationUser> _userManager;
        public FacultyController(IFaculty faculty, UserManager<ApplicationUser> userManager)
        {
            _faculty = faculty;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _faculty.GetAll();

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
        public async Task<IActionResult> Create(Faculty faculty)
        {
            //faculty.CreatedBy = _userManager.GetUserName(User);
            var createFaculty = await _faculty.AddAsync(faculty);
            
            if (createFaculty)
            {
                Alert("Faculty created successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Faculty not created!", NotificationType.error);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var editFaculty = await _faculty.GetById(id);

            if (editFaculty == null)
            {
                return RedirectToAction("Index");
            }
            return View(editFaculty);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Faculty faculty)
        {
            //var editFaculty = await _faculty.GetById(id);
            var editFaculty = await _faculty.Update(faculty, faculty.facultyID);

            if (editFaculty)
            {
                Alert("Faculty edited successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Faculty not edited", NotificationType.error);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteFaculty = await _faculty.Delete(id);
            if (deleteFaculty)
            {
                Alert("Faculty deleted successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Faculty not deleted", NotificationType.error);
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
