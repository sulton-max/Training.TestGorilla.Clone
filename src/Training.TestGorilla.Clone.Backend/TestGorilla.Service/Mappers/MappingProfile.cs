using AutoMapper;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Users;
using TestGorilla.Service.DTOs.Answers;
using TestGorilla.Service.DTOs.Categories;
using TestGorilla.Service.DTOs.Tests;
using TestGorilla.Service.DTOs.Users;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Service.DTOs.Questions;

namespace TestGorilla.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(PaginationResult<>), typeof(PaginationResult<>));
        //CreateMap<PaginationResult<>, PaginationResult<object>>();
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
            //Checkbox Questionni mapperdan o'tkazamiz
            CreateMap<CheckboxDTOs, CheckBoxQuestion>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.DurationInMinutes)));
            CreateMap<CheckBoxQuestion, CheckboxDTOs>()
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.Duration.TotalMinutes));

            //Short answer type questionni mapperdan o'tkazamiz
            CreateMap<ShortAnswerTypeDTOs, ShortAnswerTypeQuestion>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.DurationInMinutes)));
            CreateMap<ShortAnswerTypeQuestion, ShortAnswerTypeDTOs>()
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.Duration.TotalMinutes));
        // Categoryni mapperdan o'tqazyabmiz 
        CreateMap<CategoriesDTOs, Category>();
        CreateMap<Category, CategoriesDTOs>();
        
        // Testni mapperdan o'tqazamiz
        CreateMap<TestsDtos, Test>()
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.DurationInMinute)));

        CreateMap<Test, TestsDtos>()
            .ForMember(dest => dest.DurationInMinute, opt => opt.MapFrom(src => src.Duration));
        CreateMap<AnswerDto, Answer>();
        CreateMap<Answer, AnswerDto>();
    }
}
