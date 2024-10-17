using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Domain.Entities.Models
{
    public class Response
    {
        public string Message {  get; set; }
        public int Status { get; set; }
        public bool IsSuccess { get; set; } = false;

    }
}
