using BusinessObjects.Commons;
using BusinessObjects.DTOs.Professional;
using BusinessObjects.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Professional
{
    public class IndexModel : PageModel
    {
        private readonly IProfessionalService _professionalService;

        public IndexModel(IProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }

        public IEnumerable<ProfessionalDto> Professionals { get; set; }
        public IEnumerable<ProfessionalDto> PendingProfessionals { get; set; }
        public ProfessionalDto Professional { get; set; } = new();

        public PaginatedList<ProfessionalDto> ProfessionalsPaged { get; set; }

        public async Task OnGetAsync()
        {
            Professionals = await _professionalService.GetAllProfessionalAsync(ProfessionalRequestStatus.Approved);
            PendingProfessionals = await _professionalService.GetAllProfessionalAsync(ProfessionalRequestStatus.Pending);
            //ProfessionalsPaged = await PaginatedList<ProfessionalDto>.CreateAsync(Professionals.AsQueryable(), 1, 10);
        }

    }
}
