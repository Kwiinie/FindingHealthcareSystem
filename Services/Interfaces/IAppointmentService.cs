using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAppointmentService : IGenericRepository<AppointmentDTO>
    {
    }
}
