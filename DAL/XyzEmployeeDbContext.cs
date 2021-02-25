using EmployeeManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DAL
{
    public class XyzEmployeeDbContext : DbContext
    {
        public XyzEmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public virtual DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department[] {
                 new Department{ Id = 1, DepartmentName = "IT" },
                 new Department{ Id = 2, DepartmentName = "Finance" },
                 new Department{ Id = 3, DepartmentName = "HR" }
             });
        }
    }
}