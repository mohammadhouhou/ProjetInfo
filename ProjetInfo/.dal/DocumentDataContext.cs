using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal
{
    public class DocumentDataContext : DbContext
    {
        public DocumentDataContext(DbContextOptions<DocumentDataContext> opt) : base(opt)
        {

        }
        public DbSet<DocumentData> DocumentDatas { get; set; }
    }
}
