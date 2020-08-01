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
    public class SalaryService : ISalary
    {

        public CyberProjectDataContext _context;
        public SalaryService(CyberProjectDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salary>> GetAll()
        {
            return await _context.Salaries.ToListAsync();
        }
    }
}
