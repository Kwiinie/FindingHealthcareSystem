using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

namespace FindingHealthcareSystem.Pages.Admin.Article
{
    public class EditModel : PageModel
    {
        private readonly IArticleService _articleService;
        private readonly ICloudinaryService _cloudinaryService;

        public EditModel(IArticleService articleService,ICloudinaryService cloudinaryService)
        {
            _articleService = articleService;
            _cloudinaryService = cloudinaryService;
        }
        public void OnGet()
        {

        }
    }
}
