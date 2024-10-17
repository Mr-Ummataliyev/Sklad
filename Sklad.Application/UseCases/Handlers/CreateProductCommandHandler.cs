using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response>
    {
        private readonly ISkladDbContext _context;

        public CreateProductCommandHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
           
                var products = _context.Products.ToListAsync().Result;
                foreach (var product in products)
                {
                    if (product.Name == request.Name && product.Description == request.Description)
                    {
                        return new Response() 
                        { 
                            IsSuccess = false,
                            Message = "This product already exists",
                            Status = 400
                            
                        };
                    }

                }
                var newProduct = new Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Amount = request.Amount,
                    Price = request.Price,
                    AmountCat = request.AmountCat,
                    LastUpdatetime = DateTime.UtcNow,
                };
                await _context.Products.AddAsync(newProduct);
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
