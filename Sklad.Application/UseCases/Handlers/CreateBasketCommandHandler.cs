using MediatR;
using Sklad.Application.Abstraction;
using Sklad.Application.UseCases.Commands;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Handlers
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, Response>
    {
        private readonly ISkladDbContext _context;

        public CreateBasketCommandHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new Response { IsSuccess = false, Message = "Basket is null", Status = 400 };

            }
            else { 
              var product = _context.Products.FirstOrDefault(x=>x.Id==request.ProductId);
                if (product == null) {
                    return new Response { IsSuccess = false, Message = "Such product not found", Status = 404 };

                }
                else if (product.Amount<request.Amount)
                {
                    return new Response { IsSuccess = false, Message = $"We have only {product.Amount} {product.AmountCat} of {product.Name}", Status = 201 };
                }

                else
                {
                    product.Amount -= request.Amount;
                    var newBasket = new Basket
                    {
                        ProductId = request.ProductId,
                        Amount = request.Amount,
                        Paid = request.Paid,
                        TotalPrice = request.TotalPrice,
                        Bought = DateTime.UtcNow,
                    };
                    await _context.Baskets.AddAsync(newBasket);
                    await _context.SaveChangesAsync();
                    return new Response { IsSuccess = true, Message = "Created", Status = 200 };

                }

         


            }
        }
    }
}
