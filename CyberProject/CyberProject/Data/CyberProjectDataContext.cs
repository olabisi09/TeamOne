using CyberProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Data
{
    public class CyberProjectDataContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public CyberProjectDataContext(DbContextOptions<CyberProjectDataContext> options) : base(options)
        {
        }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<User> WebUsers { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
    }
}
 