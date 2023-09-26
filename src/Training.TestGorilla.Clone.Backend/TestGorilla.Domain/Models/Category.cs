using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Domain.Models
{
    public class Category : Auditable
    {
        public string Name { get; set; }
        public Category()
        {
            
        }
    }
}
