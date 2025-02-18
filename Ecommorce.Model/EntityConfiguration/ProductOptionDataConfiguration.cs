using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
    public class ProductOptionDataConfiguration : IEntityTypeConfiguration<ProductOptionData>
    {
        public void Configure(EntityTypeBuilder<ProductOptionData> builder)
        {
            builder.HasKey(pov => pov.Id);

            // One-to-One: OptionValue & OptionData
            builder.HasOne(od => od.OptionValue)
            .WithOne(ov => ov.OptionData)
            .HasForeignKey<ProductOptionData>(od => od.ValueID);
        }
    }


     public class ProductOptionValueConfiguration : IEntityTypeConfiguration<ProductOptionValue>
    {
        public void Configure(EntityTypeBuilder<ProductOptionValue> builder)
        {
            builder.HasKey(pov => pov.Id);

            // One-to-One: OptionValue & OptionData
           builder .HasOne(ov => ov.ProductOption)
            .WithMany(po => po.OptionValues)
            .HasForeignKey(ov => ov.OptionID);
        }
    }
}