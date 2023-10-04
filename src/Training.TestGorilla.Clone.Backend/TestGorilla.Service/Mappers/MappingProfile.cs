using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Users;
using TestGorilla.Service.DTOs.Categories;
using TestGorilla.Service.DTOs.Tests;
using TestGorilla.Service.DTOs.Users;

namespace TestGorilla.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            // Categoryni mapperdan o'tqazyabmiz 
            CreateMap<CategoriesDTOs, Category>();
            CreateMap<Category, CategoriesDTOs>();

            // Testni mapperdan o'tqazamiz
            CreateMap<TestsDtos, Test>();
            CreateMap<Test, TestsDtos>();
        }
    }
}
