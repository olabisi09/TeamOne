using CyberProject.Data;
using CyberProject.Entities;
using CyberProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Services
{
    public class DepartmentService : IDepartment
    {
        public CyberProjectDataContext _context;
        public DepartmentService(CyberProjectDataContext context)
        {
            _context = context;
        }

        public void Add(Department department)
        {
            
            _context.Add(department);
            _context.SaveChanges();
        }

        public async Task<bool> AddAsync(Department department)
        {
            try
            {
                await _context.AddAsync(department);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            var department = await _context.Departments.FindAsync(Id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            //return await _context.Departments.ToListAsync();
            return await _context.Departments.Include(f => f.Faculty).ToListAsync();
        }

        public async Task<Department> GetById(int Id)
        {
            var department = await _context.Departments.FindAsync(Id);
            return department;
        }

        //public async Task<bool> Update(Department department)
        //{
        //    var dept = await _context.Departments.FindAsync(department.deptID);
        //    if (dept != null)
        //    {
        //        dept.deptName = department.deptName;
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}

        public async Task<bool> Update(Department department)
        {
            var dept = await _context.Departments.FindAsync(department.deptID);
            if (dept != null)
            {
                dept.deptName = department.deptName;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
