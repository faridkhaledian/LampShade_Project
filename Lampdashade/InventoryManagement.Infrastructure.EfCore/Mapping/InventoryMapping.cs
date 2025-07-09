using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Infrastructure.EfCore.Mapping
{
   public class InventoryMapping :IEntityTypeConfiguration<Inventory>
    {

        public void Configure(EntityTypeBuilder<Inventory> builder    )
        {

        }

    }
}
