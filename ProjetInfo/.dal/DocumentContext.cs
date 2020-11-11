using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class DocumentContext : DbContext
    {

        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Document> Documents { get; set; }
    }
        
}
