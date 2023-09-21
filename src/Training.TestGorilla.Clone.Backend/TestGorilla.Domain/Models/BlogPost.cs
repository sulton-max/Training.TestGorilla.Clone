using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Domain.Models
{
    public class BlogPost
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

    }
}
