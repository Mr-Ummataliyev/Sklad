using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Domain.DTOs
{
    public class DaylyTrades
    {
        public int TotalTrade {  get; set; }
        public int TotalProductCost {  get; set; }
        public List<Basket> Basket { get; set; }
    }
}
