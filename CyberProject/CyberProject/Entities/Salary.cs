using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Entities
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryId { get; set; }
        public int GradeId { get; set; }
        public string PayItem { get; set; }
        public string PayItemType { get; set; }
        public float Amount { get; set; }
        public Grade Grade { get; set; }
    }
}
