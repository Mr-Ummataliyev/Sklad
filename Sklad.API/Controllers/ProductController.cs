using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sklad.Application.UseCases.Commands;
using Sklad.Application.UseCases.Queries;
using Sklad.Domain.Entities.Models;

namespace Sklad.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Response> CreateProduct(CreateProductCommand command)
        {
            var res = await _mediator.Send(command);
            return res;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(int pageIndex, int size)
        {
            var res = await _mediator.Send(new GetAllProductQuery { PageIndex = pageIndex, Size = size });
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> SerchProducts(int pageIndex, int size, string name)
        {
            var res = await _mediator.Send(new SearchProductQuery { PageIndex = pageIndex, Size = size, Name = name });
            return Ok(res);
        }
        [HttpDelete]
        public async Task<Response> DeleteProduct(int ProductId)
        {
            var res = await _mediator.Send(new DeleteProductCommand { ProductId = ProductId });
            return res;
        }
        [HttpPut]
        public async Task<Response> UpdateProduct(UpdateProductCommand command)
        {
            var res = await _mediator.Send(command);
            return res;
        }
    }
}
