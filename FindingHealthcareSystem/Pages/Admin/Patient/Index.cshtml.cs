using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Services;

namespace FindingHealthcareSystem.Pages.Admin.Patient
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<PatientDTO> Patients { get; set; }

        public async Task OnGetAsync()
        {
            Patients = await _userService.GetAllPatientAsync();
        }



        public async Task<IActionResult> OnPostApproveAsync(int professionalId)
        {
            return await ProcessRequest(professionalId);
        }



        private async Task<IActionResult> ProcessRequest(int userid)
        {


            try
            {


                var user = await _userService.GetUserByIdAsync(userid);
                if (user.Status.Equals(UserStatus.Active.ToString()))
                {
                    user.Status = UserStatus.Inactive.ToString();

                }
                else
                {
                    user.Status = UserStatus.Active.ToString();

                }

                await _userService.UpdateUserStatus(user);

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Lỗi khi xử lý yêu cầu: {ex.Message}");
                return Page();
            }
        }
    }
}
