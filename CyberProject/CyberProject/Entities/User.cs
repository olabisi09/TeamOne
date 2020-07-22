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
        public int FacultyID { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Grade { get; set; }
        public string Level { get; set; }
        public string Step { get; set; }
        //public float Salary { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Department Department { get; set; }
        public Faculty Faculty { get; set; }
    }
}
