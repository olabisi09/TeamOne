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
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyberProject.Controllers
{
    public class DepartmentController : BaseController
    {
        private IDepartment _department;
        private IFaculty _faculty;

        [BindProperty]
        public Department Department { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;
        public DepartmentController(IFaculty faculty, IDepartment department, UserManager<ApplicationUser> userManager)
        {
            _department = department;
            _faculty = faculty;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _department.GetAll();

            if (model != null)
                return View(model);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var dept = await _faculty.GetAll();
            var deptList = dept.Select(d => new SelectListItem()
            {
                Value = d.facultyID.ToString(),
                Text = d.facultyName
            });
            ViewBag.dept = deptList;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            var createDepartment = await _department.AddAsync(department);

            if (createDepartment)
            {
                Alert("Department created successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Department not created!", NotificationType.error);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var editDepartment = await _department.GetById(id);

            if (editDepartment == null)
            {
                return RedirectToAction("Index");
            }

            var fac = await _faculty.GetAll();
            var FacList = fac.Select(f => new SelectListItem()
            {
                Value = f.facultyID.ToString(),
                Text = f.facultyName
            });

            ViewBag.fac = FacList;

            //return View();
            return View(editDepartment);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            //var editDepartment = await _department.GetById(id);
            var editDepartment = await _department.Update(department);

            if (editDepartment && ModelState.IsValid)
            {
                Alert("Department edited successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Department not edited", NotificationType.error);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteDepartment = await _department.Delete(id);
            if (deleteDepartment)
            {
                Alert("Department deleted successfully", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Department not deleted", NotificationType.error);
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
