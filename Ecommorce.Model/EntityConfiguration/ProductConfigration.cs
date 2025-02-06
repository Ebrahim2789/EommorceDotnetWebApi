using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.EntityConfiguration
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.CostPrice).HasColumnType("decimal(18,2)");
            

            builder.HasOne(p => p.Categroy)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategroyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.Publisher)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull);




        }
    }
    public class ProductOptionDataConfiguration : IEntityTypeConfiguration<ProductOptionData>
    {
        public void Configure(EntityTypeBuilder<ProductOptionData> builder)
        {
            builder.HasKey(pod => pod.Id);
            builder.Property(pod => pod.Value).IsRequired().HasMaxLength(50);

            builder.HasOne(pod => pod.ProductOption)
                   .WithMany(po => po.ProductOptionDatas)
                   .HasForeignKey(pod => pod.OptionId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

    public class ProductOptionValueConfiguration : IEntityTypeConfiguration<ProductOptionValue>
    {
        public void Configure(EntityTypeBuilder<ProductOptionValue> builder)
        {
            builder.HasKey(pov => pov.Id);

            builder.HasOne(pov => pov.Product)
                   .WithMany(p => p.ProductOptionValues)
                   .HasForeignKey(pov => pov.ProductId);

            builder.HasOne(pov => pov.ProductOptionData)
                   .WithMany()
                   .HasForeignKey(pov => pov.ProductOptionDataId);
        }
    }



    public class ProductAtributeDataConfiguration : IEntityTypeConfiguration<ProductAttributeData>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeData> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(pa=>pa.ProductAttribute)
                .WithMany(pa=>pa.Attributes)
                .HasForeignKey(pa=>pa.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull) ;
;
        }
    }

    public class ProductAtributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(p => p.Product)
                .WithMany(p => p.AttributesValues)
                .HasForeignKey(p => p.ProductId);
            builder.HasOne(p=>p.Attribute)
                .WithMany()
                .HasForeignKey(p=>p.AttributeId);

        }
    }
}