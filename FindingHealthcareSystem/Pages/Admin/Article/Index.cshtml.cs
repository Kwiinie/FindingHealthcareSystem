using BusinessObjects.DTOs.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;

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

        [TempData]
        public string StatusMessage { get; set; }


        public ArticleDTO Article { get; set; } = new();

        public async Task OnGetAsync()
        {
            Articles = await _articleService.GetAllArticlesAsync();
        }

        public async Task<IActionResult> OnPostAsync(int articleId, bool currentStatus)
        {
            try
            {
                var article = await _articleService.GetArticleByIdAsync(articleId);
                currentStatus = article.IsDeleted;
                if (article == null)
                {
                    StatusMessage = $"Error: Article with ID {articleId} not found.";
                    return RedirectToPage();
                }

                if (currentStatus == true)
                {
                    article.IsDeleted = false;
                }
                else
                {
                    article.IsDeleted = true;

                }

                bool updateSuccess = await _articleService.UpdateArticleAsync(article);

                if (updateSuccess)
                {
                    StatusMessage = article.IsDeleted
                        ? $"Bài viết '{article.Title}' đã dừng xuất bản."
                        : $"Bài viết '{article.Title}' đã xuất bản.";
                }
                else
                {
                    StatusMessage = $"Lỗi: Không thể thay đổi trạng thái bài viết.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return RedirectToPage();
        }
    }
}
