using AutoMapper;
using BusinessObjects.Commons;
using BusinessObjects.DTOs.Appointment;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Result<AppointmentDTO>> AddAsync(CreateAppointmentDto entity)
        {
            try
            {
                if (entity.ProviderType == ProviderType.Professional)
                {
                    var professional = await _unitOfWork.ProfessionalRepository.GetByIdAsync(entity.ProviderId.Value);
                    if (professional == null)
                    {
                        return Result<AppointmentDTO>.ErrorResult("Invalid Professional ID.");
                    }
                }
                else if (entity.ProviderType == ProviderType.Facility)
                {
                    var facility = await _unitOfWork.FacilityRepository.GetByIdWithRelationsAsync(entity.ProviderId.Value);
                    if (facility == null)
                    {
                        return Result<AppointmentDTO>.ErrorResult("Invalid Facility ID.");
                    }
                }
                else
                {
                    return Result<AppointmentDTO>.ErrorResult("Invalid ProviderType.");
                }

                var appointmentEntity = _mapper.Map<Appointment>(entity);
                await _unitOfWork.AppointmentRepository.AddAsync(appointmentEntity);
                await _unitOfWork.SaveChangesAsync();
                var appointmentDTO = _mapper.Map<AppointmentDTO>(appointmentEntity);
                return Result<AppointmentDTO>.SuccessResult(appointmentDTO);
            }
            catch (Exception ex)
            {
                return Result<AppointmentDTO>.ErrorResult($"An error occurred while creating the appointment: {ex.Message}");
            }
        }

        public async Task<List<AppointmentDTO>> GetAllAsync()
        {
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync();
            return _mapper.Map<List<AppointmentDTO>>(appointments);
        }

        public async Task<List<AppointmentDTO>> GetAppointmentsByProviderAndDate(int providerId, string providerType, DateTime date)
        {
            ProviderType type = (ProviderType)Enum.Parse(typeof(ProviderType), providerType);
            var appointments = await _appointmentRepository.GetAppointmentsByProviderAndDateAsync(type, providerId, date);
            return _mapper.Map<List<AppointmentDTO>>(appointments);
        }
    }
}
