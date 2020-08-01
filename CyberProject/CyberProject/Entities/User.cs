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
        public string Country { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int gradeID { get; set; }
        public Department Department { get; set; }
        public Grade Grade { get; set; }
    }
}
