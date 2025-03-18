using AutoMapper;
using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Professional;
using BusinessObjects.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SpecialtyDto>> GetAllSpecialties()
        {
            var specialtyRepo = _unitOfWork.GetRepository<Specialty>();
            var specs = await specialtyRepo.GetAllAsync();
            if (specs == null || !specs.Any())
            {
                return new List<SpecialtyDto>();
            }
            return _mapper.Map<List<SpecialtyDto>>(specs);
        }
    }
}
