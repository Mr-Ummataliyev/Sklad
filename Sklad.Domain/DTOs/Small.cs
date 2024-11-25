using Sklad.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sklad.Domain.DTOs
{
    public class Small
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Amount { get; set; }
        
        [JsonIgnore]
        public Guid BasketId { get; set; }

        [JsonIgnore]
        public virtual Basket Basket { get; set; }
    }
}
