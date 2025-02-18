using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{

    public class ProductAtributeDataConfiguration : IEntityTypeConfiguration<ProductAttributeData>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeData> builder)
        {
            builder.HasKey(builder => builder.Id);

            // One-to-One: AttributeValue & AttributeData
            builder.HasOne(ad => ad.AttributeValue)
                   .WithOne(av => av.AttributeData)
                 .HasForeignKey<ProductAttributeData>(ad => ad.ValueID);


   

    


        }
    }
}