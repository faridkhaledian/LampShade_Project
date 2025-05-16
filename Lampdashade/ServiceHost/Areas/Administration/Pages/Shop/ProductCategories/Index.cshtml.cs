using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {

        public List<ProductCategoryViewModel> ProductCategories;

        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;


        }
        public void OnGet(ProductCategorySearchModel searchModel)
        {
           
              ProductCategories = _productCategoryApplication.Search(searchModel);


        }
    }
}
