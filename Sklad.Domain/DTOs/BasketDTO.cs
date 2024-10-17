using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Domain.DTOs
{
    public class BasketDTO
    {
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public int Paid { get; set; }
        public int TotalPrice { get; set; }

    }
}
