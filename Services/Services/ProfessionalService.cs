using AutoMapper;
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
    public class ProfessionalService : IProfessionalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProfessionalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        /// <summary>
        /// GET PROFESSIONAL BY ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProfessionalDto> GetById(int id)
        {
            var professional = await _unitOfWork.ProfessionalRepository.GetByIdAsync(id);
            return _mapper.Map<ProfessionalDto>(professional);
        }



        /// <summary>
        /// SEARCHING PROFESSIONALS BASED ON LOCATION, SPECIALTY AND NAME
        /// </summary>
        /// <param name="province"></param>
        /// <param name="district"></param>
        /// <param name="ward"></param>
        /// <param name="specialty"></param>
        /// <param name="professionalName"></param>
        /// <returns>LIST PROFESSIONALS WITH USER INFO, SERVICE INFO, LIST SPECIALTY AND EXPERTISE</returns>
        public async Task<IEnumerable<ProfessionalDto>> SearchAsync(string? province,
                                                                    string? district,
                                                                    string? ward,
                                                                    string? specialty,
                                                                    string? professionalName)
        {

            var professionals = await _unitOfWork.ProfessionalRepository.SearchAsync(
             province, district, ward, specialty, professionalName);

            var professionalDtos = _mapper.Map<IEnumerable<ProfessionalDto>>(professionals);

            return professionalDtos;
        }




    }
}
