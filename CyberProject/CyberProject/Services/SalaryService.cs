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
            return await _context.Salaries.Include(g => g.Grade).Include(u => u.User).ToListAsync();
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

        public void GetSalary(Salary salary)
        {
            float percentOne = 5;
            float percentTwo = 3;

            if (salary.User.Grade.GradeName == "Senior Staff")
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

                _context.SaveChanges();
            }

            if (salary.User.Grade.GradeName == "Junior Staff")
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
        }

        public async Task<Salary> GetById(int Id)
        {
            await _context.Salaries.Include(u => u.User).Include(g => g.Grade).ToListAsync();
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
