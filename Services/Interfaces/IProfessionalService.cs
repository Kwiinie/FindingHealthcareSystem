using BusinessObjects.DTOs.Facility;
using BusinessObjects.DTOs.Professional;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProfessionalService
    {
        Task<IEnumerable<ProfessionalDto>> SearchAsync(string? province = null,
                                                            string? district = null,
                                                            string? ward = null,
                                                            string? specialty = null,
                                                            string? professionalName = null);
    }
}
