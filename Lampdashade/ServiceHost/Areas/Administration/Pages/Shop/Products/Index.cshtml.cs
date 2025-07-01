using System.Collections.Generic;
using System.Xml.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;


        private readonly IProductApplication _productApplication;
        private readonly IProductPitureApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication , IProductPitureApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
             

        }
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories() , "Id" , "Name");
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate() {

            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };


            return Partial("./Create" ,command );

            }

        public JsonResult OnPostCreate(CreateProduct command) {
            var result = _productApplication.Create(command);
        return new JsonResult(result);
        
        }



        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
           product.Categories= _productCategoryApplication.GetProductCategories();
            return Partial("Edit" , product);


        }
         public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);

        }



        //Handler NotInStock
        public IActionResult OnGetNotInStock(long id) { 
        var result = _productApplication.NotInStock(id);
            if (result.IsSucceddd)
            {
                return RedirectToPage("./Index");

            }
                Message=result.Message;
            return RedirectToPage("./Index");
        }


        //Handler IsInStock
        public IActionResult OnGetIsInStock(long id) {
            var result = _productApplication.IsStock(id);
            if (result.IsSucceddd)
            {
                return RedirectToPage("./Index");

            }

            Message = result.Message;
            return RedirectToPage("./Index");


        }


    }
}
