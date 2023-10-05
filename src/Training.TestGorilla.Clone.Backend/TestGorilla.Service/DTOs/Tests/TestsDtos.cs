using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Entities;

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

        public static explicit operator TestsDtos(Test entity)
        {
            return new TestsDtos
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                DurationInMinute = entity.Duration


            };
        }

        public static explicit operator Test(TestsDtos dto)
        {
            return new Test
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Duration = dto.DurationInMinute

            };
        }
    }
}
