using BusinessObjects.DTOs.Professional;
using FindingHealthcareSystem.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;
using Services.Services;

namespace FindingHealthcareSystem.Pages.Professional
{
    public class DetailModel : BasePageModel
    {
        private readonly IProfessionalService _professionalService;

        public DetailModel (IProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }


        public ProfessionalDto professional { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public async Task OnGet()
        {
            professional = await _professionalService.GetById(Id);
        }
    }
}
