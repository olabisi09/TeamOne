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

        public bool GetSalary(Grade grade)
        {
            try
            {
                float percentOne = 5;

                grade.TaxPercentage = 5;
                grade.Tax = grade.Amount * (grade.TaxPercentage / 100);
                grade.TaxPayType = "Deduction";

                grade.Housing = (percentOne / 100) * grade.Amount;
                //grade.HousingPayType = "Allowance";
                if (grade.HousingPayType == "Allowance")
                {
                    grade.Amount += grade.Housing;
                }
                else if (grade.HousingPayType == "Deduction")
                {
                    grade.Amount -= grade.Housing;
                }

                grade.Medical = grade.Amount * (percentOne / 100);
                //grade.MedicalPayType = "Allowance";
                if (grade.MedicalPayType == "Allowance")
                {
                    grade.Amount += grade.Medical;
                }
                else if (grade.MedicalPayType == "Deduction")
                {
                    grade.Amount -= grade.Medical;
                }

                grade.Lunch = grade.Amount * (percentOne / 100);
                //grade.LunchPayType = "Allowance";
                if (grade.LunchPayType == "Allowance")
                {
                    grade.Amount += grade.Lunch;
                }
                else if (grade.LunchPayType == "Deduction")
                {
                    grade.Amount -= grade.Lunch;
                }

                grade.Transport = grade.Amount * (percentOne / 100);
                //grade.TransportPayType = "Allowance";
                if (grade.TransportPayType == "Allowance")
                {
                    grade.Amount += grade.Transport;
                }
                else if (grade.TransportPayType == "Deduction")
                {
                    grade.Amount -= grade.Transport;
                }

                grade.NetSalary = (grade.Amount - grade.Tax) + grade.Housing + grade.Medical + grade.Lunch + grade.Transport;
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
                //float percentOne = 5;

                grade.TaxPercentage = 5;
                grade.Tax = grade.Amount * (grade.TaxPercentage / 100);
                grade.TaxPayType = "Deduction";

                //grade.Housing = (percentOne / 100) * grade.Amount;
                //grade.HousingPayType = "Allowance";
                if (grade.HousingPayType == "Allowance")
                {
                    grade.Amount += grade.Housing;
                }
                else if (grade.HousingPayType == "Deduction")
                {
                    grade.Amount -= grade.Housing;
                }

                //grade.Medical = grade.Amount * (percentOne / 100);
                //grade.MedicalPayType = "Allowance";
                if (grade.MedicalPayType == "Allowance")
                {
                    grade.Amount += grade.Medical;
                }
                else if (grade.MedicalPayType == "Deduction")
                {
                    grade.Amount -= grade.Medical;
                }

                //grade.Lunch = grade.Amount * (percentOne / 100);
                //grade.LunchPayType = "Allowance";
                if (grade.LunchPayType == "Allowance")
                {
                    grade.Amount += grade.Lunch;
                }
                else if (grade.LunchPayType == "Deduction")
                {
                    grade.Amount -= grade.Lunch;
                }

                //grade.Transport = grade.Amount * (percentOne / 100);
                //grade.TransportPayType = "Allowance";
                if (grade.TransportPayType == "Allowance")
                {
                    grade.Amount += grade.Transport;
                }
                else if (grade.TransportPayType == "Deduction")
                {
                    grade.Amount -= grade.Transport;
                }

                grade.NetSalary = (grade.Amount - grade.Tax) + grade.Housing + grade.Medical + grade.Lunch + grade.Transport;
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
                grade.Amount = 0;
                GetSalary(grade);
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
