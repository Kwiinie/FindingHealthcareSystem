using BusinessObjects.DTOs.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Facility.Service
{
    public class IndexModel : PageModel
    {
        private readonly IFacilityTypeService _facilityTypeService;

        public IndexModel(IFacilityTypeService facilityTypeService)
        {
            _facilityTypeService = facilityTypeService;
        }

        public IEnumerable<FacilityTypeDto> FacilityTypes { get; set; }

        public async Task OnGet()
        {
            FacilityTypes = await _facilityTypeService.GetAllFacilityTypes();
        }

    }
}
