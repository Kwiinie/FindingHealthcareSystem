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
using BusinessObjects.DTOs.Professional;
using BusinessObjects.DTOs.Service;
using BusinessObjects.DTOs.Appointment;
using BusinessObjects.DTOs;
using BusinessObjects.Enums;
using BusinessObjects.DTOs.Payment;

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
            CreateMap<Specialty, SpecialtyDto>().ReverseMap();
            CreateMap<PublicService, ServiceDto>().ReverseMap();
            CreateMap<PrivateService, ServiceDto>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Payment, PaymentDto>()
            .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src =>
                        src.Appointments != null && src.Appointments.Any()
                        ? src.Appointments.First().Id
                        : (int?)null
            ));






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

            CreateMap<Appointment, MyAppointmentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date ?? DateTime.MinValue))
                .ForMember(dest => dest.ProviderId, opt => opt.MapFrom(src => src.ProviderId))
                .ForMember(dest => dest.ProviderType, opt => opt.MapFrom(src => src.ProviderType))
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src =>
                            src.ServiceType == ServiceType.Private
                            ? (object)src.PrivateService
                            : src.PublicService
                ))
                .ForMember(dest => dest.Professional, opt => opt.MapFrom(src => src.Professional))
                .ForMember(dest => dest.Facility, opt => opt.MapFrom(src => src.Facility))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Payment != null ? src.Payment.TransactionId : null))
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        }
    }
}
