using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Article
{
    public class DetailModel : PageModel
    {
        private readonly IArticleService _articleService;

        public DetailModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IActionResult> OnGetArticlesDetails()
        {

            return Page();
        }
    }
}
