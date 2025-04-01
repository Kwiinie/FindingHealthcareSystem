using BusinessObjects.Entities;
using BusinessObjects.Enums;
using DataAccessObjects.Interfaces;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects.DAOs;

namespace Repositories.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly IGenericDAO<Appointment> _dao;

        public AppointmentRepository(IGenericDAO<Appointment> dao) : base(dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// GET THE APPOINTMENT WITH PROVIDER ID AND DATE (FOR CHECKING BOOKING SLOT)
        /// </summary>
        /// <param name="providerType"></param>
        /// <param name="providerId"></param>
        /// <param name="date"></param>
        /// <returns>LIST OF APPOINTMENTS WITH THAT PROFESSIONAL/FACILITY ON THAT DAY</returns>
        public async Task<IEnumerable<Appointment>> GetAppointmentsByProviderAndDateAsync(ProviderType providerType,
                                                                                           int providerId,
                                                                                           DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = date.Date.AddDays(1).AddTicks(-1);

            var filters = new Dictionary<string, object?>
            {
                { "ProviderType", providerType },
                { "ProviderId", providerId },
            };
            var validStatuses = new[]
            {
                AppointmentStatus.AwaitingPayment,
                AppointmentStatus.Pending,
                AppointmentStatus.Confirmed,
                AppointmentStatus.Rescheduled,
                AppointmentStatus.Completed
            };

            var appointmentQuery = _dao.GetFilteredQuery(filters);
            var appointmentsForDay = await appointmentQuery
            .Where(a => a.Date >= startOfDay && a.Date <= endOfDay &&
                   validStatuses.Contains(a.Status))
            .ToListAsync();

            return appointmentsForDay;
        }

        public async Task<IEnumerable<Appointment>> GetMyAppointment(int patientId)
        {
            return await _dao.FindAllAsync(
                a => a.PatientId == patientId && !a.IsDeleted,
                includeProperties: "Professional.User,Professional.Expertise,Professional.ProfessionalSpecialties.Specialty,Professional.PrivateServices,Facility,Payment,PrivateService,PublicService"
            );
        }


    }
}
