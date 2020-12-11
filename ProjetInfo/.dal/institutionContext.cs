using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class InstitutionContext : DbContext
    {
        //I Changed this file
        public InstitutionContext(DbContextOptions<InstitutionContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Institution> Institutions { get; set; }
    }
}
