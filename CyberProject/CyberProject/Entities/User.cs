using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int DepartmentID { get; set; }
        public string ApplicationUserId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }

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

        public string PhoneNo { get; set; }
        public int gradeID { get; set; }
        public Department Department { get; set; }
        public Grade Grade { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
