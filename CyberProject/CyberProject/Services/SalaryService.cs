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
        public IUser _user;
        public SalaryService(CyberProjectDataContext context, IUser user)
        {
            _context = context;
            _user = user;
        }
         
        public async Task<IEnumerable<Salary>> GetAll()
        {
            return await _context.Salaries.ToListAsync();
        }

        public void Add(Salary salary)
        {
            _context.Add(salary);
            _context.SaveChanges();
        }

        public async Task<bool> AddAsync(Salary salary)
        {
            try
            {
                

                await _context.AddAsync(salary);
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
            var salary = await _context.Salaries.FindAsync(Id);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<Salary> GetById(int Id)
        {
            await _context.Salaries.ToListAsync();
            var s = await _context.Salaries.FindAsync(Id);

            return s;
        }

        public async Task<bool> Update(Salary salary)
        {
            var s = await _context.Salaries.FindAsync(salary.SalaryId);
            if (s != null)
            {
                //s.TaxPercentage = salary.TaxPercentage;
                s.Amount = salary.Amount;

                salary.NetSalary = (s.Amount - salary.Tax) + salary.Housing + salary.Medical + salary.Lunch + salary.Transport;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
