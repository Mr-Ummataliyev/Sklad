
using Microsoft.EntityFrameworkCore;
using Sklad.Domain.DTOs;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.Abstraction
{
    public interface ISkladDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Small> Smalls { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default );

    }
}
