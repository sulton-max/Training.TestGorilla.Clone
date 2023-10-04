using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Service.DTOs.Questions
{
    public class MultipleChoiceDTOs
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public MultipleChoiceDTOs()
        {
            
        }
    }
}
