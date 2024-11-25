using MediatR;
using Microsoft.EntityFrameworkCore;
using Sklad.Application.Abstraction;
using Sklad.Application.UseCases.Queries;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Handlers
{
    public class GetAllBasketQueryHandler : IRequestHandler<GetAllBasketQuery, IEnumerable<Basket>>
    {
        private readonly ISkladDbContext _context;

        public GetAllBasketQueryHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Basket>> Handle(GetAllBasketQuery request, CancellationToken cancellationToken)
        {
            if (request.PageIndex == 0 || request.Size == 0)
            {
                return Enumerable.Empty<Basket>();
            }

            var baskets = await _context.Baskets
          .Include(b => b.BuyedProducts)  
          .OrderBy(b => b.Bought)         
          .Skip((request.PageIndex - 1) * request.Size)  
          .Take(request.Size)                  
          .ToListAsync();
           return baskets;
     
        }
    }
}
