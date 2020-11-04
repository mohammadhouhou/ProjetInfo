using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Projet_Informatique.dal.Data
{
    public class InstitutionContext :DbContext
    {
        public InstitutionContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Institution> institutions { get; set; }
    }
}
