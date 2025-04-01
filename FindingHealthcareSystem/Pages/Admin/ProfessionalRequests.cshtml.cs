using BusinessObjects.Commons;
using BusinessObjects.DTOs.Professional;
using BusinessObjects.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin
{
    public class ProfessionalRequestsModel : PageModel
    {
        private readonly IProfessionalService _professionalService;

        public ProfessionalRequestsModel(IProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }

        public IEnumerable<ProfessionalDto> PendingProfessionals { get; set; }
        public ProfessionalDto Professional { get; set; } = new();

        public PaginatedList<ProfessionalDto> ProfessionalsPaged { get; set; }

        public async Task OnGetAsync()
        {
            PendingProfessionals = await _professionalService.GetAllProfessionalAsync(ProfessionalRequestStatus.Pending);
        }
    }
}
