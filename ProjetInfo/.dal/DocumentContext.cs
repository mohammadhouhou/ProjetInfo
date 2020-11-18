using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class DocumentContext : DbContext
    {
        public DocumentContext (DbContextOptions<DocumentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Document> Documents { get; set; } 
    }
}
