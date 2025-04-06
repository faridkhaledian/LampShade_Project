﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
   public interface IProductCategoryApplication
    {

        OperationResult Create(CreateProductCategory commend);
        OperationResult Edit(EditProductCategory commend);
    EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

            




    }
}
