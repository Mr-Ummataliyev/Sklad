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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly ISkladDbContext _context;

        public GetAllProductQueryHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            if (request.PageIndex == 0 || request.Size==0)
            {
                return Enumerable.Empty<Product>();
            }

            return await _context.Products
                   .Skip((request.PageIndex - 1)*request.Size)
                       .Take(request.Size)
                           .ToListAsync(cancellationToken);
        }
    }
}
