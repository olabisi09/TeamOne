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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Faculty>()
            .HasIndex(p => new { p.facultyName, p.facultyCode })
            .IsUnique(true);

            builder.Entity<Department>()
            .HasIndex(p => new { p.deptName })
            .IsUnique(true);

            builder.Entity<Grade>()
            .HasIndex(p => new { p.GradeName, p.Level, p.Step })
            .IsUnique(true);

        }

        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<User> WebUsers { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
    }
}
 