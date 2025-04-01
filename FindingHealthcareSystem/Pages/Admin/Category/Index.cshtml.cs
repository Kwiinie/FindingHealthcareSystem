using BusinessObjects.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<CategoryDTO> Categories { get; set; }

        public async Task OnGet()
        {
            Categories = await _categoryService.GetAllCategoriesAsync();
        }
    }
}
