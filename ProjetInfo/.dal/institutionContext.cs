using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class institutionContext : DbContext
    {
        public institutionContext(DbContextOptions<institutionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<institution> institutions { get; set; }
        //public DbSet<ActivityCategory> activityCategories { get; set; }
        //public DbSet<CourseComponentType> courseComponentTypes { get; set; }
    }
}
