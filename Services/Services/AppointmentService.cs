using AutoMapper;
using BusinessObjects.Commons;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Appointment> _repo;
        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repo = unitOfWork.GetRepository<Appointment>();
        }

        public Task AddAsync(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDTO>> FindAllAsync(Expression<Func<AppointmentDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO> FindAsync(Expression<Func<AppointmentDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AppointmentDTO>>(await _repo.GetAllAsync());
        }

        public Task<AppointmentDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<AppointmentDTO>> GetPagedListAsync(Expression<Func<AppointmentDTO, bool>> filter, int pageIndex, int pageSize, Func<IQueryable<AppointmentDTO>, IOrderedQueryable<AppointmentDTO>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Remove(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
