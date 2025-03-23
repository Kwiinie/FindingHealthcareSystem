using BusinessObjects.DTOs.User;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FindingHealthcareSystemContext _context;
        public UserRepository( FindingHealthcareSystemContext context) {
        
            _context = context;
        }


        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
          
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<List<FacilityDepartment>> GetAllHospitalsAsync()
        {
            return await _context.FacilityDepartments.ToListAsync();
        }

        public async Task<List<Specialty>> GetAllSpecialtiesAsync()
        {

            return await _context.Specialties.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task RegisterUserAsync(RegisterUserDto userDto)
        {
            try
            {
                // Validate phone number (must be exactly 10 digits)
                if (string.IsNullOrEmpty(userDto.PhoneNumber) || !Regex.IsMatch(userDto.PhoneNumber, @"^\d{10}$"))
                {
                    throw new Exception("Phone number must be exactly 10 digits.");
                }

                // Kiểm tra email đã tồn tại chưa
                bool emailExists = await _context.Users.AnyAsync(p => p.Email == userDto.Email);
                if (emailExists)
                {
                    throw new Exception("Email đã tồn tại. Vui lòng sử dụng email khác.");
                }

                var user = new User
                {
                    Fullname = userDto.Fullname,
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber,
                    Password = userDto.Password, // Lưu ý: Cần mã hóa mật khẩu
                    Role = userDto.Role,
                    ImgUrl = userDto.ImgUrl,
                    Status = UserStatus.Active,
                    Birthday = userDto.Birthday,
                    Gender = userDto.Gender
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();



                if (userDto.Role == Role.Professional)
                {
                    var professional = new Professional
                    {
                        UserId = user.Id,
                        Province = userDto.Province,
                        Ward = userDto.Ward,
                        District = userDto.District,
                        Address = userDto.Address,
                        WorkingHours = userDto.WorkingHours,
                        Degree = userDto.Degree,
                        ExpertiseId = userDto.ExpertiseId,
                        Experience = userDto.Experience,
                        RequestStatus = ProfessionalRequestStatus.Pending
                    };

                    _context.Professionals.Add(professional);
                    await _context.SaveChangesAsync();

                    foreach (var specialtyId in userDto.SpecialtyIds)
                    {
                        _context.ProfessionalSpecialties.Add(new ProfessionalSpecialty
                        {
                            ProfessionalId = professional.Id,
                            SpecialtyId = specialtyId
                        });
                    }
                    await _context.SaveChangesAsync();

                }


                if (userDto.Role == Role.Patient)
                {
                    string note = userDto.Note;
                    if (note == null) note = "N/A";
                    var patient = new Patient
                    {
                        Note = note,
                        UserId = user.Id
                    };

                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();

                   
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error in RegisterUserAsync: {ex.Message}");

                // Re-throw exception for controller to handle
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }

        public async Task<List<Expertise>> GetAllExpertises()
        {
            return await _context.Expertises.ToListAsync();
        }



        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
