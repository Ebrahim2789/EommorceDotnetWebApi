using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
    public class ProductMediaConfiguration : IEntityTypeConfiguration<ProductMedia>
    {
        public void Configure(EntityTypeBuilder<ProductMedia> builder)
        {
            // Many-to-Many: Product & Media
            builder.HasKey(pm => new { pm.ProductID, pm.MediaID });

            builder.HasOne(pm => pm.Product)
                        .WithMany(p => p.ProductMedia)
                        .HasForeignKey(pm => pm.ProductID);

            builder.HasOne(pm => pm.Media)
                    .WithMany(m => m.ProductMedia)
                    .HasForeignKey(pm => pm.MediaID);
        }
    }
}