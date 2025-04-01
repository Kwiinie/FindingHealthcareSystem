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

            var appointmentQuery = _dao.GetFilteredQuery(filters);
            var appointmentsForDay = appointmentQuery
                .Where(a => a.Date >= startOfDay && a.Date <= endOfDay)
                .ToList();

            return appointmentsForDay;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppoinmentByDate(int id, DateTime startDate, DateTime endDate)
        {
            return await _dao.Query().Include(a => a.Patient).Include(a => a.Patient.User).Include(a => a.Professional)
                .Where(a => a.Date >= startDate && a.Date <= endDate && a.Professional.UserId == id && a.ProviderId == a.Professional.Id)
                .ToListAsync();
        }


        public async Task<int> CountAppointmentByStatus(int id, string status)
        {
            var query = _dao.Query().Include(x => x.Professional);
            if (string.IsNullOrEmpty(status))
            {
                return await query.Where(a => a.Professional.UserId == id && a.ProviderId == a.Professional.Id).CountAsync();
            }
            return await _dao.Query().Where(a => a.Professional.UserId == id && a.ProviderId == a.Professional.Id && a.Status.ToString().Equals(status)).CountAsync();
        }

        public async Task<Appointment?> GetAppointment(int id)
        {
            return await _dao.Query().Include(a => a.Patient).Include(a => a.Patient.User).Include(a => a.Professional).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Appointment> Query()
        {
            return _dao.Query();
        }
    }
}
