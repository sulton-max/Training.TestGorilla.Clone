﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Users;
using TestGorilla.Service.DTOs.Answers;
using TestGorilla.Service.DTOs.Users;

namespace TestGorilla.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<AnswerDto, Answer>();
            CreateMap<Answer, AnswerDto>();
        }
    }
}