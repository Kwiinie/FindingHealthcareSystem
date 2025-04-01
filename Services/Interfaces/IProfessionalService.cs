using BusinessObjects.Commons;
using BusinessObjects.DTOs.Facility;
using BusinessObjects.DTOs.Professional;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        Task<ProfessionalDto> GetById (int id);

        Task<PaginatedList<ProfessionalDto>> GetProfessionalsPagedAsync(
        Expression<Func<Professional, bool>> filter = null,
        int pageIndex = 1,
        int pageSize = 10,
        Func<IQueryable<Professional>, IOrderedQueryable<Professional>> orderBy = null);

        Task<IEnumerable<ProfessionalDto>> GetAllProfessionalAsync(ProfessionalRequestStatus requestStatus);
    }
}
