using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EFCore
{
 public   class DiscountContext : DbContext
    {
      

        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }


        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly= typeof(CustomerDiscount).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder); 
        }



    }
}
