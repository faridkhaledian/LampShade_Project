﻿using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class FooterViewComponent :ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
