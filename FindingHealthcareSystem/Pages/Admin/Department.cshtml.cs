using BusinessObjects.DTOs.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin
{
    public class DepartmentsModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public List<DepartmentDto> Departments { get; set; }

        public async Task OnGetAsync()
        {
            Departments = await _departmentService.GetAllDepartments();
        }

        public async Task<IActionResult> OnPostCreateAsync(DepartmentDto department)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _departmentService.Create(department);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(DepartmentDto department)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _departmentService.Update(department.Id, department);
            return RedirectToPage();
        }
    }
}
