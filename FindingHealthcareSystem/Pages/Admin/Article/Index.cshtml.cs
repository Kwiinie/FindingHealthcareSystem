using BusinessObjects.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindingHealthcareSystem.Pages.Admin.Article
{
    public class IndexModel : PageModel
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        
        public IndexModel(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public IEnumerable<ArticleDTO>? Articles { get; set; }

        public ArticleDTO Article { get; set; } = new();

        public async Task OnGetAsync()
        {
            Articles = await _articleService.GetAllArticlesAsync();
        }
    }
}
