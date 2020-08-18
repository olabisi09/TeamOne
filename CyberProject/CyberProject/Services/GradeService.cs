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

        public bool GetSalary()
        {
            try
            {
                Grade grade = new Grade();
                float percentOne = 5;
                float percentTwo = 3;

                if (grade.GradeID == 1)
                {
                    //salary.Amount = 500000;

                    grade.Salary.TaxPercentage = 5;
                    grade.Salary.Tax = grade.Salary.Amount * (grade.Salary.TaxPercentage / 100);
                    grade.Salary.TaxPayType = "Deduction";

                    grade.Salary.Housing = (percentOne / 100) * grade.Salary.Amount;
                    grade.Salary.HousingPayType = "Allowance";

                    grade.Salary.Medical = grade.Salary.Amount * (percentOne / 100);
                    grade.Salary.MedicalPayType = "Allowance";

                    grade.Salary.Lunch = grade.Salary.Amount * (percentOne / 100);
                    grade.Salary.LunchPayType = "Allowance";

                    grade.Salary.Transport = grade.Salary.Amount * (percentOne / 100);
                    grade.Salary.TransportPayType = "Allowance";


                }

                if (grade.GradeID == 2)
                {
                    //grade.Salary.Amount = 100000;

                    grade.Salary.TaxPercentage = 3;
                    grade.Salary.Tax = grade.Salary.Amount * (grade.Salary.TaxPercentage / 100);
                    grade.Salary.TaxPayType = "Deduction";

                    grade.Salary.Housing = (percentTwo / 100) * grade.Salary.Amount;
                    grade.Salary.HousingPayType = "Allowance";

                    grade.Salary.Medical = grade.Salary.Amount * (percentTwo / 100);
                    grade.Salary.MedicalPayType = "Allowance";

                    grade.Salary.Lunch = grade.Salary.Amount * (percentTwo / 100);
                    grade.Salary.LunchPayType = "Allowance";

                    grade.Salary.Transport = grade.Salary.Amount * (percentTwo / 100);
                    grade.Salary.TransportPayType = "Allowance";


                }
                grade.Salary.NetSalary = (grade.Salary.Amount - grade.Salary.Tax) + grade.Salary.Housing + grade.Salary.Medical + grade.Salary.Lunch + grade.Salary.Transport;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
            
        }

        public async Task<bool> AddAsync(Grade grade)
        {
            try
            {
                float percentOne = 5;

                grade.Salary.TaxPercentage = 5;
                grade.Salary.Tax = grade.Salary.Amount * (grade.Salary.TaxPercentage / 100);
                grade.Salary.TaxPayType = "Deduction";

                grade.Salary.Housing = (percentOne / 100) * grade.Salary.Amount;
                grade.Salary.HousingPayType = "Allowance";

                grade.Salary.Medical = grade.Salary.Amount * (percentOne / 100);
                grade.Salary.MedicalPayType = "Allowance";

                grade.Salary.Lunch = grade.Salary.Amount * (percentOne / 100);
                grade.Salary.LunchPayType = "Allowance";

                grade.Salary.Transport = grade.Salary.Amount * (percentOne / 100);
                grade.Salary.TransportPayType = "Allowance";
                grade.Salary.NetSalary = (grade.Salary.Amount - grade.Salary.Tax) + grade.Salary.Housing + grade.Salary.Medical + grade.Salary.Lunch + grade.Salary.Transport;
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
            return await _context.Grades.Include(s => s.Salary).ToListAsync();
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
