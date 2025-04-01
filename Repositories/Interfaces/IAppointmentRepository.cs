using BusinessObjects.Entities;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByProviderAndDateAsync(ProviderType providerType,
                                                                                           int providerId,
                                                                                           DateTime date);
        Task<IEnumerable<Appointment>> GetMyAppointment(int patientId);
    }
}
