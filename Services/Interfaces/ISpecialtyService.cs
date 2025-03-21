using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Professional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISpecialtyService
    {
        Task<List<SpecialtyDto>> GetAllSpecialties();

    }
}
