using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Commons;

namespace TestGorilla.Domain.Models
{
    public class Category : Auditable, IEntity
    {
        public string Name { get; set; }
        public Category()
        {
            
        }
    }
}
