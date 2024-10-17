using MediatR;
using Sklad.Application.Abstraction;
using Sklad.Application.UseCases.Queries;
using Sklad.Domain.DTOs;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Handlers
{
    public class SearchBasketByDayQueryHandler : IRequestHandler<SearchBasketByDayQuery, DaylyTrades>
    {
        private readonly ISkladDbContext _context;

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
            var StartDate = DateTime.UtcNow.AddDays(request.Day*-1);
            
            var baskets =_context.Baskets.Where(x=> x.Bought >=StartDate).ToList();
            var totaltrade = 0;
            var totalProductCost = 0;
            foreach (Basket basket in baskets) {
                totalProductCost += basket.TotalPrice;
                totaltrade += basket.Paid;
            
            }
            return new DaylyTrades { TotalProductCost=totalProductCost, TotalTrade=totaltrade, Basket = baskets};
            
        }
    }
}
