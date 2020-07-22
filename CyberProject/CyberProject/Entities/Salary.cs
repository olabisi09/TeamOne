using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public float salary { get; set; }
        public float Tax { get; set; }
        public float NetSalary { get; set; }
        public User user { get; set; }
    }
}
