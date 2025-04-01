using BusinessObjects.DTOs.Facility;
using BusinessObjects.DTOs.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Facility.Service
{
    public class IndexModel : PageModel
    {
        private readonly IPublicServiceLayer _publicService;

        public IndexModel(IPublicServiceLayer publicService)
        {
            _publicService = publicService;
        }

        public IEnumerable<ServiceDto> Services { get; set; }

        public async Task OnGet()
        {
            Services = await _publicService.GetAllFacilities();
        }

    }
}
