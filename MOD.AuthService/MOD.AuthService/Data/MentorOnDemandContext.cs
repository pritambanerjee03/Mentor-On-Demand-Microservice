﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOD.AuthService.Model;
using MOD.AuthService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthService.Data
{
    public class MentorOnDemandContext : IdentityDbContext
    {
        public MentorOnDemandContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>(r => r.HasData(new IdentityRole
            {
                Id = "1",
                Name= "Admin",
                NormalizedName = "Admin"
            },
            new IdentityRole
            {
                Id = "2",
                Name= "Mentor",
                NormalizedName = "Mentor"

            },
            new IdentityRole
            {
                Id = "3",
                Name= "Student",
                NormalizedName = "Student"
            }
            ));

            base.OnModelCreating(builder);
        }
        public DbSet<MODUser> MODUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EnrolledCourse> EnrolledCourses { get; set; }

    }
}
