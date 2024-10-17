using MediatR;
using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Application.UseCases.Queries
{
    public class SearchProductQuery : IRequest<IEnumerable<Product>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
    }
}
