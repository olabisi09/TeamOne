using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Models
{
    public class CreateUserModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string LGA { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Grade { get; set; }

        [Required]
        public string EmpLevel { get; set; }

        [Required]
        public string Step { get; set; }

        [Required]
        public string Salary { get; set; }

        [Required]
        public string TaxOnSalary { get; set; }

        [Required]
        public string NetSalary { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
