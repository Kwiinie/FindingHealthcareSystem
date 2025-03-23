using BusinessObjects.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;
using Services.Services;

namespace FindingHealthcareSystem.Pages.Admin.Article
{
    public class CreateModel : PageModel
    {
        private readonly IArticleService _articleService;
        private readonly ICloudinaryService _cloudinaryService;
        public CreateModel(IArticleService articleService, ICloudinaryService cloudinaryService)
        {
            _articleService = articleService;
            _cloudinaryService = cloudinaryService;
        }

        [BindProperty]
        public ArticleDTO Article { get; set; }

        [BindProperty]
        public List<IFormFile> ImageFiles { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // 1️⃣ Tạo Article trước
            await _articleService.AddArticleAsync(Article);

            // 2️⃣ Upload ảnh lên Cloudinary nếu có
            if (ImageFiles != null && ImageFiles.Count > 0)
            {
                foreach (var file in ImageFiles)
                {
                    await _cloudinaryService.UploadImageArticle(file, Article.Id);
                }
            }

            return RedirectToPage("/Admin/Article/Index");
        }
    }
}
