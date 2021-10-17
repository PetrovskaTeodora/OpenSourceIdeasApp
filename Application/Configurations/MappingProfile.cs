using Application.DTO_Models;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Idea, IdeaDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
