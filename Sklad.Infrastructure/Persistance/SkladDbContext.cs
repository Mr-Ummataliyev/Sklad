using Microsoft.EntityFrameworkCore;
using Sklad.Application.Abstraction;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Infrastructure.Persistance
{
    public class SkladDbContext : DbContext, ISkladDbContext
    {
        public SkladDbContext (DbContextOptions<SkladDbContext> options) 
            : base(options)
        {
           Database.Migrate();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}
