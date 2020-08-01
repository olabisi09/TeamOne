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
        public int Level { get; set; }
        public int Step { get; set; }
    }
}
