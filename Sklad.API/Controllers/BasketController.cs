using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sklad.Application.UseCases.Commands;
using Sklad.Application.UseCases.Queries;
using Sklad.Domain.DTOs;
using Sklad.Domain.Entities.Models;

namespace Sklad.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Basket>> GetAllBasket(int pageIndex, int pageSize) { 
               var res = await _mediator.Send(new GetAllBasketQuery { PageIndex = pageIndex, Size = pageSize});
               return res;
        
        }
        [HttpGet]
        public async Task<DaylyTrades> SearchBasketByDay(int day)
        {
            var res = await _mediator.Send(new SearchBasketByDayQuery { Day = day});
            return res;

        }
        [HttpPost]
        public async Task<Response> CreateBasket(CreateBasketCommand command)
        {
            var res = await _mediator.Send(command);
            return res;

        }
        [HttpDelete]
        public async Task<Response> DeleteBasket(Guid BasketId)
        {
            var res = await _mediator.Send(new  DeleteBasketCommand { BasketId = BasketId });
            return res;
        }
    }
}
