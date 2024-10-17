using MediatR;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Queries
{
    public class GetAllBasketQuery : IRequest<IEnumerable<Basket>>
    {

    }
}
