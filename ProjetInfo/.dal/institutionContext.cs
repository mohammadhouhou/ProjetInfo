﻿using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class InstitutionContext : DbContext
    {
        public InstitutionContext(DbContextOptions<InstitutionContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
        }*/
        public DbSet<Institution> institutions { get; set; }
        //public DbSet<ActivityCategory> activityCategories { get; set; }
        //public DbSet<CourseComponentType> courseComponentTypes { get; set; }
    }
}
