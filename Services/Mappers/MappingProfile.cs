using AutoMapper;
using BusinessObjects.Dtos.User;
using BusinessObjects.DTOs.Auth;
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
using BusinessObjects.DTOs.Professional;
using BusinessObjects.DTOs.Service;
using BusinessObjects.DTOs.Appointment;
using BusinessObjects.DTOs;
using BusinessObjects.DTOs.Category;

namespace Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GeneralUserDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<FacilityType, FacilityTypeDto>().ReverseMap();
            CreateMap<FacilityDepartment, FacilityDepartmentDto>().ReverseMap();
            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();

            CreateMap<Article, ArticleDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy.Fullname));
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Specialty, SpecialtyDto>().ReverseMap();
            CreateMap<PublicService, ServiceDto>().ReverseMap();
            CreateMap<PrivateService, ServiceDto>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();

            /////////////////////////////////////////////////////////////////////////
            ///MAPPING PROFESSIONAL EXPERTISE, SPECIALTY, USER INFO, SERVICE INFO///
            ///////////////////////////////////////////////////////////////////////
            CreateMap<Professional, ProfessionalDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.Fullname))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
           .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.User.ImgUrl))
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User.Gender))
           .ForMember(dest => dest.ExpertiseName, opt => opt.MapFrom(src => src.Expertise.Name))
           .ForMember(dest => dest.Specialties, opt => opt.MapFrom(src => src.ProfessionalSpecialties.Select(ps => ps.Specialty.Name).ToList()))
           .ForMember(dest => dest.PrivateServices, opt => opt.MapFrom(src => src.PrivateServices.Select(ps => new ServiceDto
           {
               Id = ps.Id,
               Name = ps.Name,
               Price = ps.Price,
               Description = ps.Description
           }).ToList()));


            ////////////////////////////////////////////////////////////////
            ///MAPPING FACILITY WITH TYPE, DEPARTMENT NAME, SERVICE INFO///
            //////////////////////////////////////////////////////////////
            CreateMap<Facility, SearchingFacilityDto>()
            .ForMember(dest => dest.FacilityTypeName, opt => opt.MapFrom(src => src.Type.Name)) 
            .ForMember(dest => dest.DepartmentNames, opt => opt.MapFrom(src => src.FacilityDepartments.Select(fd => fd.Department.Name).ToList())) 
            .ForMember(dest => dest.PublicServices, opt => opt.MapFrom(src => src.PublicServices.Select(ps => new ServiceDto
            {
                Id = ps.Id,
                Name = ps.Name,
                Price = ps.Price,
                Description = ps.Description
            }).ToList()));


            /////////////////////////////////////////////////////////////////////////
            ///                     MAPPING APPOINTMENT PROFILE                  ///
            ///////////////////////////////////////////////////////////////////////
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();

            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();

        }
    }
}
