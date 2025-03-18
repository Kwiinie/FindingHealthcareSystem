using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Facility;
using BusinessObjects.DTOs.Professional;
using FindingHealthcareSystem.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Search
{
    public class IndexModel : BasePageModel
    {
        private readonly IFacilityService _facilityService;
        private readonly IProfessionalService _professionalService;
        private readonly ISpecialtyService _specialtyService;
        private readonly IDepartmentService _departmentService;

        public IndexModel(IFacilityService facilityService, IProfessionalService professionalService,
                         ISpecialtyService specialtyService, IDepartmentService departmentService)
        {
            _facilityService = facilityService;
            _professionalService = professionalService;
            _specialtyService = specialtyService;
            _departmentService = departmentService;
        }

        /// <summary>
        /// LIST OF ITEMS
        /// </summary>
        public IEnumerable<SearchingFacilityDto> Facilities { get; set; } = new List<SearchingFacilityDto>();
        public IEnumerable<ProfessionalDto> Professionals { get; set; } = new List<ProfessionalDto>();
        public IEnumerable<SpecialtyDto> Specialties { get; set; } = new List<SpecialtyDto>();
        public IEnumerable<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();

        /// <summary>
        /// PROPERTY TO HOLD FORM INPUTS
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchKeyword { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Province { get; set; }

        [BindProperty(SupportsGet = true)]
        public string District { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ward { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Department { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Specialty { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProviderType { get; set; } = "facility"; // Default to facility


        /// <summary>
        /// GET LIST FACILITES/PROFESSIONALS
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            Specialties = await _specialtyService.GetAllSpecialties();
            Departments = await _departmentService.GetAllDepartments();

            if (ProviderType == "facility" || string.IsNullOrEmpty(ProviderType))
            {
                Facilities = await _facilityService.SearchAsync(SearchKeyword, Province, District, Ward, Department);
                Professionals = new List<ProfessionalDto>();
            }
            else if (ProviderType == "professional")
            {
                Professionals = await _professionalService.SearchAsync(Province, District, Ward, Specialty, SearchKeyword);
                Facilities = new List<SearchingFacilityDto>();
            }
        }
    }
}
