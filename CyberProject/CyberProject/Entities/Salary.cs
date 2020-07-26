using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string EmployeeGrade { get; set; }
        public string EmployeeLevel { get; set; }
        public string EmployeeStep { get; set; }
        public float Sal { get; set; }
        public float TaxOnSalary { get; set; }
        public float NetSalary { get; set; }
        public User User { get; set; }
    }
}
