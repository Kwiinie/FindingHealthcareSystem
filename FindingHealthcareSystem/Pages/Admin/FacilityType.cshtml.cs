using BusinessObjects.DTOs.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin
{
    public class FacilityTypeModel : PageModel
    {
        private readonly IFacilityTypeService _facilityTypeService;

        public FacilityTypeModel(IFacilityTypeService facilityTypeService)
        {
            _facilityTypeService = facilityTypeService;
        }

        public List<FacilityTypeDto> FacilityTypes { get; set; }

        public async Task OnGet()
        {
            FacilityTypes = await _facilityTypeService.GetAllFacilityTypes();
        }
    }
}
