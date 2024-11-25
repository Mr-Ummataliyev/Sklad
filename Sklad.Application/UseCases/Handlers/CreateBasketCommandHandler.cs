using MediatR;
using Microsoft.EntityFrameworkCore;
using Sklad.Application.Abstraction;
using Sklad.Application.UseCases.Commands;
using Sklad.Domain.DTOs;
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
            var newBask = new Basket
            {

                Paid = request.Paid,
                TotalPrice = request.TotalPrice,
                BuyedProducts = request.BuyProducts.Select(c => new Small {ProductId = c.ProductId, ProductName = c.ProductName, ProductDescription = c.ProductDescription, Amount = c.Amount}).ToList()

            };
            foreach (var i in newBask.BuyedProducts) {
                var a = await _context.Products.FirstOrDefaultAsync(c=> c.Id == i.ProductId);
                if (a == null) {
                    return new Response()
                    {
                        IsSuccess = false,
                        Message = $"PRODUCT WITH ID {i.ProductId} NOT FOUND",
                        Status = 404

                    };

                }
                else if (a.Amount < i.Amount)
                {
                    return new Response()
                    {
                        IsSuccess = false,
                        Message = $"Sorry we have only {a.Amount} {a.AmountCat} of {a.Name}",
                        Status = 201

                    };
                }
                else
                {
                    a.Amount -= i.Amount;
                }
            
            }

             await _context.Baskets.AddAsync(newBask);
             await _context.SaveChangesAsync();
            return new Response()
            {
                IsSuccess = true,
                Message = "Created Successfuly",
                Status = 200

            };
        }
    }
}
