using BusinessObjects.DTOs.Professional;
using BusinessObjects.Entities;
using FindingHealthcareSystem.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Services.Interfaces;
using Services.Services;

namespace FindingHealthcareSystem.Pages.Professional
{
    public class DetailModel : BasePageModel
    {
        private readonly IProfessionalService _professionalService;
        private readonly IUserService _userService;
        public DetailModel (IProfessionalService professionalService, IUserService userService)
        {
            _professionalService = professionalService;
            _userService = userService;
        }
        public BusinessObjects.Entities.Professional CurrentUser { get; set; } // Chứa thông tin
                                                                               // user
        [BindProperty]
        public BusinessObjects.Entities.Professional UpdatedUser { get; set; } // Thuộc tính để binding dữ liệu từ form


        public ProfessionalDto professional { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var userJson = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToPage("/Login"); // Chưa đăng nhập -> Quay về Login
            }

            // Chỉ lấy ID từ JSON
            var userObject = JsonConvert.DeserializeObject<dynamic>(userJson);
            int userId = userObject.Id; // Lấy UserId từ Session

            // Truy vấn thông tin User từ Database
            var user = await _userService.GetUserByIdNew(userId);
            if (user == null)
            {
                return RedirectToPage("/Login"); // Nếu User không tồn tại, quay về Login
            }

            // Truy vấn thông tin Professional từ Database
            CurrentUser = await _userService.GetProfessionalById(userId);
            if (CurrentUser == null)
            {
                return RedirectToPage("/Login"); // Nếu Professional không tồn tại, quay về Login
            }

            // Khởi tạo UpdatedUser với thông tin từ cả hai bảng
            UpdatedUser = new BusinessObjects.Entities.Professional
            {
                UserId = user.Id,
                Province = CurrentUser.Province,
                District = CurrentUser.District,
                Ward = CurrentUser.Ward,
                Address = CurrentUser.Address,
                Degree = CurrentUser.Degree,
                Experience = CurrentUser.Experience,
                WorkingHours = CurrentUser.WorkingHours,
                ProfessionalSpecialties = CurrentUser.ProfessionalSpecialties,
                User = new User
                {
                    Fullname = user.Fullname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    Birthday = user.Birthday,
                    ImgUrl = user.ImgUrl
                }
            };

            return Page();
        }

        public async Task<IActionResult> OnPostEditProfile()
        {
            try {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                var userJson = HttpContext.Session.GetString("User");
                if (string.IsNullOrEmpty(userJson))
                {
                    return Unauthorized();
                }

                var userObject = JsonConvert.DeserializeObject<dynamic>(userJson);
                int userId = userObject.Id;

                var user = await _userService.GetUserByIdAsync(userId);
                if (user == null) return NotFound();

                var professional = await _userService.GetProfessionalById(userId);
                if (professional == null) return NotFound();

                // Cập nhật thông tin User
                user.Fullname = UpdatedUser.User.Fullname;
                user.Email = UpdatedUser.User.Email;
                user.PhoneNumber = UpdatedUser.User.PhoneNumber;
                user.Gender = UpdatedUser.User.Gender;
                user.Birthday = UpdatedUser.User.Birthday.GetValueOrDefault();

                // Cập nhật thông tin Professional
                professional.Province = UpdatedUser.Province;
                professional.District = UpdatedUser.District;
                professional.Ward = UpdatedUser.Ward;
                professional.Address = UpdatedUser.Address;
                professional.Degree = UpdatedUser.Degree;
                professional.Experience = UpdatedUser.Experience;
                professional.WorkingHours = UpdatedUser.WorkingHours;
                professional.ProfessionalSpecialties = UpdatedUser.ProfessionalSpecialties;
                await _userService.UpdateUserAsync(user);
                await _userService.UpdateProfessionalAsync(professional);
                TempData["SuccessMessage"] = "Thay đồi hồ sơ thành công! ";
                await OnGet();
                return Page();
            } catch (Exception ex)
            {
                await OnGet();
                TempData["ErrorMessage"] = ex.Message+ ", Thay đồi hồ sơ thành công!";
                return Page();
            }
           
        }
    }
}
