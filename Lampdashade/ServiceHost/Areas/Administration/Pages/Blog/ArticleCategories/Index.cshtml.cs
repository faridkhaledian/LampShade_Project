using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        public ArticleCategorySearchModel SearchModel;
        public List<ArticleCategoryViewModel> ArticleCategories;
        private readonly IArticleCategoryApplication _ArticleCategoryApplication;
        public IndexModel(IArticleCategoryApplication ArticleCategoryApplication)
        {
            _ArticleCategoryApplication = ArticleCategoryApplication;
        }
        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = _ArticleCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticleCategory());
        }
        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _ArticleCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var ArticleCategory = _ArticleCategoryApplication.GetDetails(id);
            return Partial("Edit", ArticleCategory);
        }
        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            //if (ModelState.IsValid)
            //{
                var result = _ArticleCategoryApplication.Edit(command);
                return new JsonResult(result);
            //}
            //return new JsonResult("Error");
        }
    }
}
