using BusinessObjects.DTOs.User;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);

        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);


        Task<List<Specialty>> GetAllSpecialtiesAsync();
        Task<List<FacilityDepartment>> GetAllHospitalsAsync();

        Task<List<Expertise>> GetAllExpertises();

        Task RegisterUserAsync(RegisterUserDto userDto);

    }
}
