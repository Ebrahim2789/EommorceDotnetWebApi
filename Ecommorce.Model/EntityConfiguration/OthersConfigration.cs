using Ecommorce.Model.Model;
using Ecommorce.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ecommorce.Model.EntityConfiguration
{ 
        public class OthersConfiguration : IEntityTypeConfiguration<Car>
        {
            public void Configure(EntityTypeBuilder<Car> modelBuilder)

            {
            modelBuilder.HasKey(x => x.Id);
            //One - to - Many Relationships
            //modelBuilder.Entity<Car>(entity =>
            //{
            //entity.Property(p => p.Display)
            //    .HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'");
            modelBuilder.Property(p => p.Display)
                    .HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'", stored: true);

                modelBuilder.Property(p => p.IsDrivable)
                         .HasField("_isDrivable")
                         .HasDefaultValue(true);
                modelBuilder.HasOne(p => p.MakeNavigation)
                      .WithMany(d => d.Cars)
                      .HasForeignKey(p => p.MakeId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Inventory_Makes_MakeId");



                modelBuilder
                     .HasMany(p => p.Drivers)
                     .WithMany(p => p.Cars)
                     .UsingEntity<CarDriver>(
                     j => j
                     .HasOne(cd => cd.DriverNavigation)
                     .WithMany(d => d.CarDrivers)
                     .HasForeignKey(nameof(CarDriver.DriverId))
                     .HasConstraintName("FK_InventoryDriver_Drivers_DriverId")
                     .OnDelete(DeleteBehavior.Cascade),
                     j => j
                     .HasOne(cd => cd.CarNavigation)
                     .WithMany(c => c.CarDrivers)
                     .HasForeignKey(nameof(CarDriver.CarId))
                     .HasConstraintName("FK_InventoryDriver_Inventory_InventoryId")
                     .OnDelete(DeleteBehavior.ClientCascade),
                     j =>
                     {
                         j.HasKey(cd => new { cd.CarId, cd.DriverId });
                     });
            }
        }


        public class MakeConfiguration : IEntityTypeConfiguration<Make>
        {
            public void Configure(EntityTypeBuilder<Make> builder)
            {
            builder.HasKey(x => x.Id);
            builder.HasMany(p => p.Cars)
                    .WithOne(p => p.MakeNavigation)
                    .HasForeignKey(p => p.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Makes_MakeId");

            }
        }


    public class RadioConfiguration : IEntityTypeConfiguration<Radio>
    {

        public void Configure(EntityTypeBuilder<Radio> builder)
        {
            ////One - to - One Relationships
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.CarId, "IX_Radios_CarId")
                        .IsUnique();


            builder.HasOne(p => p.CarNavigation)
                    .WithOne(p => p.RadioNavigation)
                    .HasForeignKey<Radio>(f => f.CarId);
        }
    }

}

