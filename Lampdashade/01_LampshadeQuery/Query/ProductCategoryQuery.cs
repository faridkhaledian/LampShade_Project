﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {

        private readonly ShopContext _Context;

        public ProductCategoryQuery(ShopContext context)
        {
            _Context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
           return _Context.ProductCategories.Select(x=> new ProductCategoryQueryModel
           {
               Id= x.Id,
               Name= x.Name,
               Picture= x.Picture,
               PictureAlt= x.PictureAlt,
               PictureTitle= x.PictureTitle,
               Slug= x.Slug

           } ).ToList();

        }
    }
}
