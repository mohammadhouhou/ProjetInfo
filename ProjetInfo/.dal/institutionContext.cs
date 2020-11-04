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
        public DbSet<institution> institutions { get; set; }
    }
}
