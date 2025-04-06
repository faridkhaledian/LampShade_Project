using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
 public   interface IProductCategoryRepository
    {

        void Create( ProductCategory entity  );
        ProductCategory Get(long id );
        List<ProductCategory> GetAll();
        bool Exists( Expression<Func<ProductCategory , bool>> expression   );
        void SaveChanges();
       EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);    
    
    
    }
}
