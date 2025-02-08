using Ecommorce.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
           builder.HasKey(x => x.Id);


            builder.Property(p => p.RefundAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.SubTotal).HasColumnType("decimal(18,2)");
            builder.Property(p => p.SubTotalWithDiscount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.OrderTotal).HasColumnType("decimal(18,2)");
            builder.Property(p => p.DiscountAmount).HasColumnType("decimal(18,2)");

      

            //RefundAmount SubTotal SubTotalWithDiscount OrderTotal DiscountAmount
        }
    }
    public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> modelBuilder)
        {

            modelBuilder.HasKey(od => new
                    {
                        od.OrderId,
                        od.ProductId
                    });

            modelBuilder.Property(p => p.ProductPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Property(p => p.DiscountAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Property(p => p.ItemAmount).HasColumnType("decimal(18,2)");

            modelBuilder.Property(p => p.ItemWeight).HasColumnType("decimal(18,2)");
            //ProductPrice DiscountAmount ItemAmount ItemWeight

            modelBuilder
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(od => od.OrderId);

            modelBuilder
                    .HasOne(od => od.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(od => od.ProductId);
        }
    }


    public class OrderAddressConfiguration : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> modelBuilder)
        {
            modelBuilder.HasKey(oa => oa.Id);

            modelBuilder.HasOne(oa => oa.Order)
                .WithMany()
                .HasForeignKey(oa => oa.OrderId);
        }

    }
}



