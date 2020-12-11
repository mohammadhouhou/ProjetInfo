using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class CourseComponentTypeContext : DbContext
    {
        public CourseComponentTypeContext(DbContextOptions<CourseComponentTypeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CourseComponentType> CourseComponentTypes { get; set; }
    }
}