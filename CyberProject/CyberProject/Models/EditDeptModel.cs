using CyberProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Models
{
    public class EditDeptModel
    {
        public int deptID { get; set; }
        public string deptName { get; set; }
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }
    }
}
