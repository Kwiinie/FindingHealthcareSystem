using BusinessObjects.Entities;
using DataAccessObjects.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.DAOs
{
    public class ProfessionalDao : GenericDAO<Professional>, IProfessionalDao
    {
        private readonly FindingHealthcareSystemContext _context;

        public ProfessionalDao(FindingHealthcareSystemContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Professional> GetByIdAsync(int id)
        {
            return await _context.Professionals
               .Include(f => f.Expertise)
               .Include(f => f.User)
               .Include(f => f.PrivateServices)
               .Include(f => f.ProfessionalSpecialties)
               .ThenInclude(f => f.Specialty)
               .FirstOrDefaultAsync(f => f.Id == id);
        }

    }
}
