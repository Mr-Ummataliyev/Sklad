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
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, Response>
    {
        private readonly ISkladDbContext _context;

        public DeleteBasketCommandHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _context.Baskets.Include(b => b.BuyedProducts).FirstOrDefaultAsync(b => b.Id == request.BasketId);
            if (basket == null)
            {
                return new Response()
                {
                    IsSuccess = true,
                    Message = $"BASKET WITH ID {request.BasketId} NOT FOUND!",
                    Status = 404

                };
            }
            else 
            { 
            
                _context.Baskets.Remove(basket);
                await _context.SaveChangesAsync();

                return new Response()
                {
                    IsSuccess = true,
                    Message = "Deleted Successfuly",
                    Status = 200

                };
            }
        }
    }
}
