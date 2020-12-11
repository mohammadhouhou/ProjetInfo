using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class ActivityCategoryContext : DbContext
    {
        public ActivityCategoryContext(DbContextOptions<ActivityCategoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ActivityCategory> ActivityCategories { get; set; }
    }
}
//njnjnnjn