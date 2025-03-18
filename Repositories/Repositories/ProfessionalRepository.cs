using BusinessObjects.Commons;
using BusinessObjects.Entities;
using DataAccessObjects.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ProfessionalRepository : GenericRepository<Professional>, IProfessionalRepository
    {
        private readonly IGenericDAO<Professional> _dao;

        public ProfessionalRepository(IGenericDAO<Professional> dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<Professional>> SearchAsync( string? province = null,
                                                                  string? district = null,
                                                                  string? ward = null,
                                                                  string? specialty = null,
                                                                  string? professionalName = null) 
        {
            var filters = new Dictionary<string, object?>();
            if (!string.IsNullOrEmpty(province))
            {
                filters.Add("Province", province);
            }

            if (!string.IsNullOrEmpty(district))
            {
                filters.Add("District", district);
            }

            if (!string.IsNullOrEmpty(ward))
            {
                filters.Add("Ward", ward);
            }

            if (!string.IsNullOrEmpty(professionalName))
            {
                filters.Add("User.Name", professionalName);
            }

            var query = _dao.GetFilteredQuery(filters, includes: new List<string> {
            "Expertise",
            "PrivateServices",
            "ProfessionalSpecialties",
            "ProfessionalSpecialties.Specialty",
            "User" 
            });

            if (!string.IsNullOrEmpty(specialty))
            {
                query = query.Where(professional =>
                    professional.ProfessionalSpecialties.Any(ps =>
                        ps.Specialty.Name != null &&
                        ps.Specialty.Name.Contains(specialty)
                    )
                );
            }

            if (!string.IsNullOrEmpty(professionalName))
            {
                query = query.Where(professional =>
                    professional.User.Fullname.Contains(professionalName));
            }


            return await query.ToListAsync();
        }
    }
}
