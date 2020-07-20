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
    public class FacultyService : IFaculty
    {
        public CyberProjectDataContext _context;
        public FacultyService(CyberProjectDataContext context)
        {
            _context = context;
        }

        public void Add(Faculty faculty)
        {
            _context.Add(faculty);
            _context.SaveChanges();
        }

        public async Task<bool> AddAsync(Faculty faculty)
        {
            try
            {
                await _context.AddAsync(faculty);
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
            var faculty = await _context.Faculties.FindAsync(Id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Faculty>> GetAll()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<Faculty> GetById(int Id)
        {
            var faculty = await _context.Faculties.FindAsync(Id);
            return faculty;
        }

        public async Task<bool> Update(Faculty faculty)
        {
            var fac = await _context.Faculties.FindAsync(faculty.facultyID);
            if (fac != null)
            {
                fac.facultyName = faculty.facultyName;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
