﻿using Sklad.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Domain.Entities.Models
{
    public class Basket
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public DateTime Bought { get; set; }= DateTime.UtcNow;
        public int Paid { get; set; }
        public int TotalPrice { get; set; }
        public virtual List<Small> BuyedProducts { get; set; }
      

    }
}
