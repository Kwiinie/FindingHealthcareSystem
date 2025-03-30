using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Interfaces
{
    public interface IProfessionalDao : IGenericDAO<Professional>
    {
        Task<Professional> GetByIdAsync(int id);

    }
}
