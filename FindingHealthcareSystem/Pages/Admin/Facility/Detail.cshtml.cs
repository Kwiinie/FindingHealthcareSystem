using BusinessObjects.DTOs.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Facility
{
    public class DetailModel : PageModel
    {
        private readonly IFacilityService _facilityService;

        public DetailModel(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public FacilityDto Facility { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Facility = await _facilityService.GetById(Id);
            if (Facility == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
