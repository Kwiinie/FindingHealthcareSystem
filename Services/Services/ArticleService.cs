using AutoMapper;
using BusinessObjects.DTOs.Article;
using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddArticleAsync(ArticleDTO articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            await _unitOfWork.ArticleRepository.AddAsync(article);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            if (article != null)
            {
                article.IsDeleted = true;
                _unitOfWork.ArticleRepository.Update(article);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ArticleDTO>> GetAllArticlesAsync()
        {
            var result = await _unitOfWork.ArticleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ArticleDTO>>(result);
        }

        public async Task<ArticleDTO> GetArticleByIdAsync(int id)
        {
            var details = await _unitOfWork.ArticleRepository.GetByIdAsync(id);
            return _mapper.Map<ArticleDTO>(details);
        }

        public async Task UpdateArticleAsync(ArticleDTO articleDto)
        {
            var article = await _unitOfWork.ArticleRepository.GetByIdAsync(articleDto.Id);
            if (article == null) return;

            _mapper.Map(articleDto, article);
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
