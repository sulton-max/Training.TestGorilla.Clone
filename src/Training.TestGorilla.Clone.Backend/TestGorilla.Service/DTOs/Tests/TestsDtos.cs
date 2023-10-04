using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Service.DTOs.Tests
{
    public class TestsDtos
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }

        public int DurationInMinute { get; set; }


        /*public TestsDtos(Guid id, string tittle, string description,  )
        {
            Id = id;
            Tittle = tittle;
            Description = description;
            Duration = Duration;
        }*/
    }
}
