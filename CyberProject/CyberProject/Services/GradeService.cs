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
    public class GradeService : IGrade
    {
        public CyberProjectDataContext _context;
        public GradeService(CyberProjectDataContext context)
        {
            _context = context;
        }

        public void Add(Grade grade)
        {
            _context.Add(grade);
            _context.SaveChanges();
        }

        public async Task<bool> AddAsync(Grade grade)
        {
            try
            {
                await _context.AddAsync(grade);
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
            var grade = await _context.Grades.FindAsync(Id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Grade>> GetAll()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> GetById(int Id)
        {
            var grade = await _context.Grades.FindAsync(Id);
            return grade;
        }

        public async Task<bool> Update(Grade grade, int Id)
        {
            var gr = await _context.Grades.FindAsync(Id);
            if (gr != null)
            {
                gr.GradeName = grade.GradeName;
                gr.Level = grade.Level;
                gr.Step = grade.Step;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
