using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.HasKey(p => p.ProductID);
            // One-to-Many: Product & ProductOption
            builder.HasOne(po => po.Product)
                 .WithMany(p => p.ProductOptions)
                 .HasForeignKey(po => po.ProductID);
        }
    }
}