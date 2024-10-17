using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Domain.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public decimal Amount { get; set; }
        public string AmountCat { get; set; }
        public DateTime LastUpdatetime { get; set; }= DateTime.UtcNow;
 

    }
}
