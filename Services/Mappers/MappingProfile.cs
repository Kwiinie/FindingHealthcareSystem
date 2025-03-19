using AutoMapper;
using BusinessObjects.Dtos.User;
using BusinessObjects.DTOs.Auth;
using BusinessObjects.DTOs;
using BusinessObjects.DTOs.Auth;
using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Facility;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DTOs.Article;

namespace Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GeneralUserDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<FacilityType, FacilityTypeDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();

            CreateMap<Article, ArticleDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy.Fullname))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ArticleImages.Select(img => img.ImgUrl).ToList()));
        }
    }
}
