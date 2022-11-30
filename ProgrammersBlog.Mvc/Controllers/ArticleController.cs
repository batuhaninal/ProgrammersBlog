﻿using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Mvc.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Mvc.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage=1, int pageSize=5, bool isAcending=false)
        {
            var searchedResult = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAcending);
            if (searchedResult.ResultStatus == ResultStatus.Success)
                return View(new ArticleSearchViewModel
                {
                    ArticleListDto = searchedResult.Data,
                    Keyword = keyword
                });
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int articleId)
        {
            var articleResult = await _articleService.GetAsync(articleId);
            if (articleResult.ResultStatus == ResultStatus.Success)
            {
                await _articleService.IncreaseViewCountAsync(articleId);
                return View(articleResult.Data);
            }
            return NotFound();
        }
    }
}
