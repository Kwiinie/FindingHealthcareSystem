using BusinessObjects.DTOs.Article;
using BusinessObjects.DTOs.Category;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Services.Interfaces;
using Services.Services;
using System.Security.Claims;
using BusinessObjects.Dtos.User;

namespace FindingHealthcareSystem.Pages.Admin.Article
{
    public class CreateModel : PageModel
    {
        private readonly IArticleService _articleService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ICategoryService _categoryService;
        public CreateModel(IArticleService articleService, ICloudinaryService cloudinaryService,ICategoryService categoryService)
        {
            _articleService = articleService;
            _cloudinaryService = cloudinaryService;
            _categoryService = categoryService;

        }

        public List<ArticleDTO> Articles { get; set; } = new();
        [BindProperty]
        public ArticleDTO Article { get; set; } = new ArticleDTO();

        public List<CategoryDTO> Categories { get; set; }

        [BindProperty]
        public List<IFormFile> ImageFiles { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var articles = await _articleService.GetAllArticlesAsync();
            ArticleDTO article = articles.FirstOrDefault();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Failed to create article. Please check your input.";
                return Page();
            }
            try
            {
                await _articleService.AddArticleAsync(Article);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
