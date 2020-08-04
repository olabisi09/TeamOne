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
        public int UserId { get; set; }
        public float Tax { get; set; }
        public float TaxPercentage { get; set; }
        public string TaxPayType { get; set; }
        public float Housing { get; set; }
        public string HousingPayType { get; set; }
        public float Transport { get; set; }
        public string TransportPayType { get; set; }
        public float Medical { get; set; }
        public string MedicalPayType { get; set; }
        public float Lunch { get; set; }
        public string LunchPayType { get; set; }
        public float Amount { get; set; }
        public float NetSalary { get; set; }
        public Grade Grade { get; set; }
        public User User { get; set; }
    }
}
