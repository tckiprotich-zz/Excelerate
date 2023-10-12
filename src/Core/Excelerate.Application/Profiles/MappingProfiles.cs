global using AutoMapper;
using Excelerate.Application.DTOs;
using Excelerate.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excelerate.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<NewMessage, NewMessageDTOs>();
            CreateMap<NewMessageDTOs, NewMessage>();
            CreateMap<NewMessageResponse, NewMessageResponseDTOs>();
            CreateMap<NewMessageResponseDTOs, NewMessageResponse>();
        }
        
    }
}