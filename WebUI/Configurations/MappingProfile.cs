using Application.DTO_Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IdeaViewModel,IdeaDTO>()
                .ReverseMap();

            CreateMap<UserLoginViewModel, UserDTO>()
                .ForMember(dest => dest.Email, x => x.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password))
                .ForMember(dest => dest.Username, x => x.Ignore())
                .ForMember(dest => dest.FirstName, x => x.Ignore())
                .ForMember(dest => dest.LastName, x => x.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Email, x => x.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password));

            CreateMap<UserRegisterViewModel, UserDTO>()
                .ForMember(dest => dest.Username, x => x.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, x => x.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, x => x.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, x => x.MapFrom(src => src.LastName))
                .ReverseMap()
                .ForMember(dest => dest.Username, x => x.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, x => x.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, x => x.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, x => x.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, x => x.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ConfirmPassword, x => x.Ignore());

        }
    }
}
