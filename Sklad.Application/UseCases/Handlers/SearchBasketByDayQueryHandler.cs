using MediatR;
using Sklad.Application.Abstraction;
using Sklad.Application.UseCases.Queries;
using Sklad.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Handlers
{
    public class SearchBasketByDayQueryHandler : IRequestHandler<SearchBasketByDayQuery, DaylyTrades>
    {
        protected readonly ISkladDbContext _context;

        public SearchBasketByDayQueryHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<DaylyTrades> Handle(SearchBasketByDayQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new DaylyTrades();
            }
            var StartDate = DateTime.UtcNow.AddDays(request.Day * -1);

            var baskets = _context.Baskets.Where(x => x.Bought >= StartDate).ToList();

            var dayly = new DaylyTrades();
            foreach (var i in baskets) 
            {
                dayly.TotalTrade += i.TotalPrice;
                dayly.TotalProductCost += i.Paid;
            
            }
            dayly.Baskets = baskets;
            return dayly;



        }
    }
}
