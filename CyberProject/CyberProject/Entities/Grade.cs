using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Entities
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeID { get; set; }
        public string GradeName { get; set; }
        public string Level { get; set; }
        public string Step { get; set; }
        public int SalaryID { get; set; }
        public Salary Salary { get; set; }
    }
}
