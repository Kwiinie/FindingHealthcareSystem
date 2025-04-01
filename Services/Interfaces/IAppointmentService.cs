using BusinessObjects.Commons;
using BusinessObjects.DTOs;
using BusinessObjects.DTOs.Appointment;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<Result<AppointmentDTO>> AddAsync(CreateAppointmentDto entity);
        Task<bool> AddAsync(AppointmentDTO createAppointmentDto);
        Task<bool> ChangeAppointmentStatus(int id, AppointmentStatus rejected);
        Task<int> CountAppointmentByStatus(int id, string v);
        Task<List<AppointmentDTO>> GetAllAppoinmentByDate(int id, DateTime monday, DateTime dateTime);
        Task<List<AppointmentDTO>> GetAllAsync();
        Task<List<AppointmentDTO>> GetAppointmentsByProviderAndDate(int providerId, string providerType, DateTime date);
        Task<AppointmentDTO> GetAsync(int id);
        Task<List<AppointmentDTO>> GetPagenagingAppointments(int pagee, int v);
        Task<List<string>> GetSlotsExistedByDate(DateTime date, List<string> slots);
        Task<List<MyAppointmentDto>> GetMyAppointment(int userId);
        Task<MyAppointmentDto?> GetMySpecificAppointment(int appointmentId);
    }
}
