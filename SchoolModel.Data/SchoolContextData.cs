using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolModel.Core;

namespace SchoolModel.Data
{
    public class SchoolContextData : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SchoolContextData(DbContextOptions<SchoolContextData> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}
