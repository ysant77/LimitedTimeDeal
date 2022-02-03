using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitedTimeDealAPI.Models
{
    public class LimitedTimeDealDbContext : DbContext
    {
        public DbSet<Deal> Deals { get; set; }

        public LimitedTimeDealDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
