﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository< long   ,ProductPicture>
    {


        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);



    }
}
