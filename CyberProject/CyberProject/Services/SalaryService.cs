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

        

        public float GetTax(Salary salary)
        {
            var tax = salary.TaxOnSalary;
            if (salary.Sal > 100000)
            {
                tax = salary.Sal * (10 / 100);
            }
            else if (salary.Sal > 50000)
            {
                tax = salary.Sal * (5 / 100);
            }
            else tax = 0;
            return tax;
        }

        public float GetNetSalary(Salary s)
        {
            var netSal = s.Sal - GetTax(s);

            return netSal;
            //await _context.AddAsync(s);
            //await _context.SaveChangesAsync();
        }
    }
}
