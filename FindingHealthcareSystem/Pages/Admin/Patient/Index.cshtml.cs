using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interfaces;
using Services.Interfaces;

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
    }
}
