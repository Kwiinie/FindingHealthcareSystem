using BusinessObjects.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Article
{
    public class IndexModel : PageModel
    {
        private readonly IArticleService _articleService;

        public IndexModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public List<ArticleDTO> Articles { get; set; } = new List<ArticleDTO>();
        public async void OnGet()
        {
            Articles = (await _articleService.GetAllArticlesAsync()).ToList();
        }
    }
}
