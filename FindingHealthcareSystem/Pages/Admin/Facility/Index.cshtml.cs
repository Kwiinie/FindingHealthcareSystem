using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Facility
{
    public class IndexModel : PageModel
    {
        private readonly IFacilityService _facilityService;
        private readonly IDepartmentService _departmentService;

        public IndexModel(IFacilityService facilityService, IDepartmentService departmentService)
        {
            _facilityService = facilityService;
            _departmentService = departmentService;
        }

        [BindProperty]
        public FacilityDto Facility { get; set; }
        [BindProperty]
        public List<DepartmentDto> Departments { get; set; }
        public IEnumerable<FacilityDto> Facilities { get; set; }

        // GET: /Admin/Facility
        public async Task OnGetAsync()
        {
            // Fetch all facilities
            Facilities = await _facilityService.GetAllFacilities();
            Departments = await _departmentService.GetAllDepartments();


            // Check if Facilities is null or empty for troubleshooting
            if (Facilities == null || !Facilities.Any())
            {
                Console.WriteLine("No facilities available.");
            }
        }

     
        public async Task<IActionResult> OnPostCreateFacilityAsync()
        {

            var count = Facility.DepartmentIds;
            var status = Facility.Status;
            var type = Facility.TypeId;
            // Call the service to save the edited facility
            await _facilityService.Create(Facility);
            // Redirect back to the index page after successful save
            return RedirectToPage("/Admin/Facility/Index");
        }
    }
}
