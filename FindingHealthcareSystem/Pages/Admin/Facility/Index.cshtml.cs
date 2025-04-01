using BusinessObjects.DTOs.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Facility
{
    public class IndexModel : PageModel
    {
        private readonly IFacilityService _facilityService;

        public IndexModel(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        public IEnumerable<FacilityDto> Facilities { get; set; }

        public async Task OnGetAsync()
        {
            Facilities = await _facilityService.GetAllFacilities();
        }
    }
}
