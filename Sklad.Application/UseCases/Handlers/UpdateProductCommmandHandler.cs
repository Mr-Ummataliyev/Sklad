using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateProductCommmandHandler : IRequestHandler<UpdateProductCommand, Response>
    {
        private readonly ISkladDbContext _context;

        public UpdateProductCommmandHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id == null)
                {

                    return new Response { IsSuccess = false, Message = "Id is empty", Status = 400 };

                }
                else
                {
                    var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (product == null)
                    {
                        return new Response { IsSuccess = false, Message = "Product not found", Status = 404 };


                    }
                    else
                    {

                        product.Name = request.Name;
                        product.Description = request.Description;
                        product.Price = request.Price;
                        product.Amount = request.Amount;
                        product.AmountCat = request.AmountCat;
                        product.LastUpdatetime = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        return new Response { IsSuccess = true, Message = "Updated", Status = 200 };


                    }


                }
            }
            catch (Exception ex) {
                return new Response { IsSuccess = false, Message = "Something went wrong", Status = 400 };

            }
        }
    }
}
