using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
    public class ProductAtributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.HasKey(builder => builder.Id);

            // One-to-Many: ProductAttribute & AttributeValue
            builder.HasOne(av => av.ProductAttribute)
                 .WithMany(pa => pa.AttributeValues)
                 .HasForeignKey(av => av.AttributeID);

        }
    }
}