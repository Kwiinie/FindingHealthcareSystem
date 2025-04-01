using BusinessObjects.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Article
{
    public class EditModel : PageModel
    {
        private readonly IArticleService _articleService;
        private readonly ICloudinaryService _cloudinaryService;
        public ArticleDTO Article {  get; set; } = new ArticleDTO();
        public EditModel(IArticleService articleService,ICloudinaryService cloudinaryService)
        {
            _articleService = articleService;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Article = await _articleService.GetArticleByIdAsync(id) ?? new ArticleDTO();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _articleService.UpdateArticleAsync(Article);
            return RedirectToPage("/Admin/Article/Index");
        }
    }
}
