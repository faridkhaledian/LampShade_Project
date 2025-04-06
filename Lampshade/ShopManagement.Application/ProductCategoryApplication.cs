using System.Collections.Concurrent;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication

    {

        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory commend)
        {
        
        var operation= new OperationResult();
            if (_productCategoryRepository.Exists( x=> x.Name == commend.Name   )   )
            {
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            }
            var slug = commend.Slug.slugify();
            var productCategory = new ProductCategory(commend.Name, commend.Description, commend.Picture
                , commend.PictureAlt, commend.PictureTitle, commend.Keywords, commend.MetaDescription,
                slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();

        
        }

        public OperationResult Edit(EditProductCategory commend)
        {
          var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(commend.Id);


            if (productCategory== null)
            {
                return operation.Failed("رکوردی با اطلاعات درخواست شده یافت نشد");
            }
            if (_productCategoryRepository.Exists(x=> x.Name==commend.Name&& x.Id == commend.Id  )  )
            {
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            }

            var slug=commend.Slug.slugify();
            productCategory.Edit(commend.Name, commend.Description, commend.Picture,
          commend.PictureAlt, commend.PictureTitle, commend.Keywords, commend.MetaDescription, slug);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();   

        }

        public EditProductCategory GetDetails(long id)
        {

            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {

            return _productCategoryRepository.Search(searchModel);

        }
    }
}
