using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Users;
using TestGorilla.Service.DTOs.Categories;
using TestGorilla.Service.DTOs.Tests;
using TestGorilla.Service.DTOs.Answers;
using TestGorilla.Service.DTOs.Users;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Service.DTOs.Questions;

namespace TestGorilla.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(PaginationResult<>), typeof(PaginationResult<>));
            //CreateMap<PaginationResult<>, PaginationResult<object>>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            // Categoryni mapperdan o'tqazyabmiz 
            CreateMap<CategoriesDTOs, Category>();
            CreateMap<Category, CategoriesDTOs>();
            //MultipleChoice Questionni mapperdan o'tkazamiz
            CreateMap<MultipleChoiceDTOs, MultipleChoiceQuestion>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.DurationInMinutes)));

            CreateMap<MultipleChoiceQuestion, MultipleChoiceDTOs>()
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.Duration.TotalMinutes));

            //Checkbox Questionni mapperdan o'tkazamiz
            CreateMap<CheckboxDTOs, CheckBoxQuestion>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.DurationInMinutes)));
            CreateMap<CheckBoxQuestion, CheckboxDTOs>();

            //Short answer type questionni mapperdan o'tkazamiz
            CreateMap<ShortAnswerTypeDTOs, ShortAnswerTypeQuestion>();
            CreateMap<ShortAnswerTypeQuestion, ShortAnswerTypeDTOs>();
            // Testni mapperdan o'tqazamiz
            CreateMap<TestsDtos, Test>();
            CreateMap<Test, TestsDtos>();

            CreateMap<AnswerDto, Answer>();
            CreateMap<Answer, AnswerDto>();
        }
    }
}
