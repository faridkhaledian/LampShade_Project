﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(1,1000000 , ErrorMessage =ValidationMessages.IsRequired) ]
        public long ProductId { get; set; }
        [Range(1, 10000000000, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
