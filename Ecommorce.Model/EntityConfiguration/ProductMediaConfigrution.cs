using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
    public class ProductMediaConfigrution : IEntityTypeConfiguration<ProductMedia>
    {
        public void Configure(EntityTypeBuilder<ProductMedia> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Medias)
                .HasForeignKey(p => p.ProductId);

        }
    }
}
