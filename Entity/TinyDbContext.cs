using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUrl.Entity
{
    public class TinyDbContext:DbContext
    {
        public TinyDbContext(DbContextOptions<TinyDbContext> options) : base(options)
        {
        }
        public DbSet<Url> Urls { get; set; }
    }
}
