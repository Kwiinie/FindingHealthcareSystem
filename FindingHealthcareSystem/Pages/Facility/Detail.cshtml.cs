using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Facility;
using BusinessObjects.DTOs.Service;
using BusinessObjects.Entities;
using BusinessObjects.LocationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Facility
{
    public class DetailModel : PageModel
    {
        private readonly IFacilityService _facilityService;
        private readonly IDepartmentService _departmentService;
        private readonly IPublicServiceLayer _publicServiceLayer;
        private readonly IFacilityTypeService _facilityTypeService;
        private readonly ILocationService _locationService;

        public DetailModel(IFacilityService facilityService, IDepartmentService departmentService, IPublicServiceLayer publicServiceLayer, IFacilityTypeService facilityTypeService, ILocationService locationService)
        {
            _facilityService = facilityService;
            _departmentService = departmentService;
            _publicServiceLayer = publicServiceLayer;
            _facilityTypeService = facilityTypeService;
            _locationService = locationService;
        }

        [BindProperty(SupportsGet = true)]
        public int FacilityId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int DepartmentId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ServiceId { get; set; }

        [BindProperty]
        public FacilityDto Facility { get; set; }

        [BindProperty]
        public List<DepartmentDto> Departments { get; set; }

        [BindProperty]
        public List<FacilityTypeDto> FacilityTypes { get; set; }

        [BindProperty]
        public List<ServiceDto> Services { get; set; }

        [BindProperty]
        public ServiceDto Service { get; set; }

        public bool IsEdit { get; private set; } = false;

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    Facility = await _facilityService.GetById(FacilityId);
        //    if (Facility == null)
        //    {
        //        throw new Exception("Facility not found");
        //    }
        //    if (IsEdit)
        //    {
        //        // If in Edit Mode, load all departments for selection
        //        Departments = await _departmentService.GetAllDepartments();
        //    }
        //    else
        //    {
        //        // If in View Mode, only show the departments associated with this facility
        //        Departments = await _departmentService.GetDepartmentsByFacilityIdAsync(FacilityId) ?? new List<DepartmentDto>();
        //    }

        //    Services = await _publicServiceLayer.GetServicesByFacilityId(FacilityId) ?? new List<ServiceDto>();
        //    return Page();
        //}
        public async Task OnGetAsync()
        {
            Facility = await _facilityService.GetById(FacilityId);
            if (Facility == null)
            {
                throw new Exception("Facility not found");
            }
            Departments = await _departmentService.GetAllDepartments();
            Services = await _publicServiceLayer.GetServicesByFacilityId(FacilityId) ?? new List<ServiceDto>();
            FacilityTypes = await _facilityTypeService.GetAllActiveFacilityTypes();
        }

        public async Task<IActionResult> OnGetAllDepartmentsAsync()
        {
            Departments = await _departmentService.GetAllDepartments();
            return Page();
        }

        public async Task<IActionResult> OnGetAllServicesAsync()
        {
            Services = await _publicServiceLayer.GetAllFacilities();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteFacilityAsync()
        {
            await _facilityService.DeleteAsync(FacilityId);
            return RedirectToPage("/Facility/Index");
        }

        public async Task<IActionResult> OnPostEditFacilityAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _facilityService.Update(FacilityId, Facility);
            return Page();
        }

        public async Task<IActionResult> OnPostAddServiceAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _publicServiceLayer.Create(FacilityId, Service);
            return RedirectToPage("/Facility/Detail", new { id = FacilityId });
        }

        //public async Task<IActionResult> OnGetDistrictsAsync(string provinceCode)
        //{
        //    if (string.IsNullOrEmpty(provinceCode))
        //    {
        //        return new JsonResult(new List<District>());
        //    }

        //    var districts = await _locationService.GetCities(provinceCode);
        //    return new JsonResult(districts);
        //}

        //public async Task<IActionResult> OnGetWardsAsync(string districtCode)
        //{
        //    if (string.IsNullOrEmpty(districtCode))
        //    {
        //        return new JsonResult(new List<Ward>());
        //    }

        //    var wards = await _locationService.GetWards(districtCode);
        //    return new JsonResult(wards);
        //}
    }
}
