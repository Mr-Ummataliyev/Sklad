using MediatR;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Commands
{
    public class DeleteProductCommand : IRequest<Response>
    {
        public int ProductId { get; set; }
    }
}
