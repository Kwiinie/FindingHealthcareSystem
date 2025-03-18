using AutoMapper;
using BusinessObjects.Commons;
using BusinessObjects.Dtos.User;
using BusinessObjects.DTOs.User;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Linq.Expressions;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper , IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<PaginatedList<GeneralUserDto>> GetUsersAsync(
            string? search,
            string? role,
            string? status,
            string? sortBy,
            bool isDescending,
            int pageIndex,
            int pageSize)
        {
            var userRepo = _unitOfWork.GetRepository<User>();

            Expression<Func<User, bool>> filter = u =>
                (string.IsNullOrEmpty(search) || u.Fullname.Contains(search) || u.Email.Contains(search) || u.PhoneNumber.Contains(search)) &&
                (string.IsNullOrEmpty(role) || u.Role.ToString() == role) &&
                (string.IsNullOrEmpty(status) || u.Status.ToString() == status);

            Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                orderBy = query =>
                {
                    return isDescending ? query.OrderByDescending(GetSortProperty(sortBy)) : query.OrderBy(GetSortProperty(sortBy));
                };
            }

            var paginatedUsers = await userRepo.GetPagedListAsync(filter, pageIndex, pageSize, orderBy);

            return new PaginatedList<GeneralUserDto>(
                paginatedUsers.Select(_mapper.Map<GeneralUserDto>).ToList(),
                paginatedUsers.Count,
                pageIndex,
                pageSize);
        }

        public async Task<GeneralUserDto?> GetUserByIdAsync(int userId)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.GetByIdAsync(userId);
            return user == null ? null : _mapper.Map<GeneralUserDto>(user);
        }

        private static Expression<Func<User, object>> GetSortProperty(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "fullname" => u => u.Fullname,
                "email" => u => u.Email,
                "phonenumber" => u => u.PhoneNumber,
                "role" => u => u.Role,
                "status" => u => u.Status,
                _ => u => u.Id
            };
        }

        public async Task AddUserAsync(GeneralUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.GetRepository<User>().AddAsync(user);
        }

        public async Task UpdateUserAsync(GeneralUserDto userDto)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.GetByIdAsync(userDto.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            _mapper.Map(userDto, user); // Update properties from DTO

            userRepo.Update(user); // No need to await since it's void
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are persisted
        }

        public async Task DeleteUserAsync(int id)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.GetByIdAsync(id);
            user.IsDeleted = true;
           
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are persisted

        }

        public async Task<List<Specialty>> GetAllSpecialtiesAsync()
        {
            return await _userRepository.GetAllSpecialtiesAsync();
        }

        public async Task<List<FacilityDepartment>> GetAllHospitalsAsync()
        {
            return await _userRepository.GetAllHospitalsAsync();
        }

        public async Task RegisterUserAsync(RegisterUserDto userDto)
        {
            try
            {
                await _userRepository.RegisterUserAsync(userDto);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Expertise>> GetAllExpertises()
        {
            return await _userRepository.GetAllExpertises();
        }
    }
}
