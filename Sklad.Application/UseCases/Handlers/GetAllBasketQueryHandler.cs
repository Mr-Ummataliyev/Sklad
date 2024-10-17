using MediatR;
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
            var res =  _context.Baskets.ToList();
            return res;
        }
    }
}
