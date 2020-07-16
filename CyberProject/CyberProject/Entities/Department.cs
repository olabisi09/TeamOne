using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Entities
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int deptID { get; set; }
        public string deptName { get; set; }
        public Faculty Faculty { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
