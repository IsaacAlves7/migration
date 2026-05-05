using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trp.Domain.Model;

namespace Trp.Domain
{
    public class TrpDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TrpDbContext(DbContextOptions<TrpDbContext> options) : base(options)
        {
        }

        public DbSet<Url> Url { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Url>().ToTable("url");
        }
    }
}
