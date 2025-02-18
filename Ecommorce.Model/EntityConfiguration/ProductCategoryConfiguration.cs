using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {


            // Many-to-Many: Product & Category
            builder.HasKey(pc => new { pc.ProductID, pc.CategoryID });


            builder.HasOne(p => p.Products)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(p => p.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Categories)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.ClientSetNull);




        }
    }
}