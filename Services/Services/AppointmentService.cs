using AutoMapper;
using BusinessObjects.Commons;
using BusinessObjects.DTOs.Appointment;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// CREATE APPOINTMENT 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Result<AppointmentDTO>> AddAsync(CreateAppointmentDto entity)
        {
            try
            {
                var patientRepo = _unitOfWork.GetRepository<Patient>();

                var patient = await patientRepo.GetByIdAsync(entity.PatientId);
                if (patient == null)
                {
                    return Result<AppointmentDTO>.ErrorResult("Invalid Patient ID.");
                }

                if (entity.ProviderType == ProviderType.Professional)
                {
                    var professional = await _unitOfWork.ProfessionalRepository.GetByIdAsync(entity.ProviderId.Value);
                    if (professional == null)
                    {
                        return Result<AppointmentDTO>.ErrorResult("Invalid Professional ID.");
                    }
                    entity.ProviderType = ProviderType.Professional;
                    entity.ServiceType = ServiceType.Private;
                }
                else if (entity.ProviderType == ProviderType.Facility)
                {
                    var facility = await _unitOfWork.FacilityRepository.GetByIdWithRelationsAsync(entity.ProviderId.Value);
                    if (facility == null)
                    {
                        return Result<AppointmentDTO>.ErrorResult("Invalid Facility ID.");
                    }
                    entity.ProviderType = ProviderType.Facility;
                    entity.ServiceType = ServiceType.Public;
                }
                else
                {
                    return Result<AppointmentDTO>.ErrorResult("Invalid ProviderType.");
                }

                entity.Status = AppointmentStatus.AwaitingPayment;
                var appointmentEntity = _mapper.Map<Appointment>(entity);
                appointmentEntity.Patient = patient;

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

        public async Task<bool> AddAsync(AppointmentDTO createAppointmentDto)
        {
            try
            {
                var entity = _mapper.Map<Appointment>(createAppointmentDto);
                await _unitOfWork.AppointmentRepository.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ChangeAppointmentStatus(int id, AppointmentStatus rejected)
        {
            try
            {
                var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
                if (appointment == null)
                {
                    return false;
                }
                appointment.Status = rejected;
                _unitOfWork.AppointmentRepository.Update(appointment);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> CountAppointmentByStatus(int id, string status)
        {
            return await _unitOfWork.AppointmentRepository.CountAppointmentByStatus(id, status);
        }

        public async Task<List<AppointmentDTO>> GetAllAppoinmentByDate(int id, DateTime startDate, DateTime endDate)
        {
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAppoinmentByDate(id, startDate, endDate);
            return _mapper.Map<List<AppointmentDTO>>(appointments);
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

        public async Task<AppointmentDTO> GetAsync(int id)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetAppointment(id);
            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task<List<AppointmentDTO>> GetPagenagingAppointments(int pagee, int size)
        {
            var list = (await _unitOfWork.AppointmentRepository.Query().Include(x => x.Patient).Include(x => x.Patient.User).ToListAsync())
                .OrderByDescending(x => x.Date).Skip((pagee - 1) * size).Take(size).ToList();
            return _mapper.Map<List<AppointmentDTO>>(list);
        }

        public async Task<List<string>> GetSlotsExistedByDate(DateTime date, List<string> slots)
        {
            var slotsInDay = await _appointmentRepository
                .Query()
                .Where(x => x.Date.HasValue && x.Date.Value.Day == date.Day && x.Date.Value.Month == date.Month && x.Date.Value.Year == date.Year)
                .ToListAsync();

            var slotsExisted = slotsInDay
                .Select(x => x.Date.Value.ToString("HH:mm"))
                .Where(slot => slots.Contains(slot))
                .ToList();

            return slotsExisted;
        }
    }
}
