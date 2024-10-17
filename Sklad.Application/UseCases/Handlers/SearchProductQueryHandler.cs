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
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, IEnumerable<Product>>
    {
        private readonly ISkladDbContext _context;

        public SearchProductQueryHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {

                return Enumerable.Empty<Product>();

            }
            else { 
              var products = await _context.Products.Where(x=> 
              x.Name.Contains(request.Name)||x.Description.Contains(request.Name))
                      .Skip((request.PageIndex - 1) * request.Size)
                       .Take(request.Size)
                         .ToListAsync(cancellationToken);
                return products;
            
            }
        }
    }
}
