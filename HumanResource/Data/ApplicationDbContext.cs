using HumanResource.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResource.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ExtraAndDiscount> ExtraAndDiscounts { get; set; }
        public DbSet<Holidayes> Holidayes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<OfficialVacations> OfficialVacations { get; set; }
        public DbSet<HourWorks> HourWorks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<HumanResource.Models.Attendance> Attendance { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<IdentityUser>().Ignore()
        //                                       .Ignore(c => c.LockoutEnabled)
                                               
        //                                       .Ignore(c => c.Roles)
        //                                       .Ignore(c => c.TwoFactorEnabled);//and so on...

        //    modelBuilder.Entity<IdentityUser>().ToTable("Users");//to change the name of table.

        //}
    }
}
