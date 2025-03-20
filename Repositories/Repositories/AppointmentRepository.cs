using BusinessObjects.Entities;
using DataAccessObjects.Interfaces;
using Repositories.Interfaces;
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
    }
}
