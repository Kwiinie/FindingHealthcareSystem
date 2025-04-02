using BusinessObjects.DTOs.Professional;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin
{
    public class SpecialtyModel : PageModel
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyModel(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        public List<SpecialtyDto> Specialties { get; set; } = new List<SpecialtyDto>();

        [BindProperty]
        public SpecialtyDto Specialty { get; set; } = new SpecialtyDto();

        public async Task OnGetAsync()
        {
            Specialties = await _specialtyService.GetAllSpecialties();
        }

    }
}
