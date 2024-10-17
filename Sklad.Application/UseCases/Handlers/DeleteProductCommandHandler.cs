using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sklad.Application.Abstraction;
using Sklad.Application.UseCases.Commands;
using Sklad.Domain.Entities.Models;

namespace Sklad.Application.UseCases.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response>
    {
        private readonly ISkladDbContext _context;

        public DeleteProductCommandHandler(ISkladDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.ProductId);
            if (product == null) {
                return new Response()
                {
                    IsSuccess = false,
                    Message = "Product not found",
                    Status = 404
                };
            }
            var del = _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return new Response() 
            { 
                IsSuccess = true,
                Message = "Deleted",
                Status = 200
            };
        }
    }
}
