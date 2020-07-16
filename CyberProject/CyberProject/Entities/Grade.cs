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
        public int gradeID { get; set; }
        public string gradeName { get; set; }
        public int level { get; set; }
        public int step { get; set; }
    }
}
