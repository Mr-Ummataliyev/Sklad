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
        public async Task<IEnumerable<Basket>> GetAllBasket() { 
               var res = await _mediator.Send(new GetAllBasketQuery());
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
    }
}
