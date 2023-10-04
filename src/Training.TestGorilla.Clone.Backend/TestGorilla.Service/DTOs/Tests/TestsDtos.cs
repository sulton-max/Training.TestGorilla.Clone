using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGorilla.Service.DTOs.Tests
{
    public class TestsDtos
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }

        public TestsDtos()
        {

        }

        public TestsDtos(Guid id, string tittle, string description, TimeSpan duration)
        {
            Id = id;
            Tittle = tittle;
            Description = description;
            Duration = duration;
        }
    }
}
