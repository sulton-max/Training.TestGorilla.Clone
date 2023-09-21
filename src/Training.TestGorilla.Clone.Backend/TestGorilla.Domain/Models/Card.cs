using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Domain.Models
{
    public class Card
    {
        public long Id { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }

    }
}
