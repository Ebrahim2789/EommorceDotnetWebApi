using Ecommorce.Model.Model;
using Microsoft.EntityFrameworkCore;
using Ecommorce.Model.UserModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ecommorce.Model.IdentityModel;

namespace Ecommorce.Model
{
    public class ApplicationDbContext : IdentityDbContext<UsersIdentity,RoleIdentity,string>
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarDriver> CarsToDrivers { get; set; }

        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(50);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFollower>()
                .HasKey(uf => new { uf.FollowerId,uf.FollowingId});

            modelBuilder.Entity<UserFollower>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(u => u.FollowerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UserFollower>()
              .HasOne(uf => uf.Following)
              .WithMany(u => u.Followers)
              .HasForeignKey(u => u.FollowingId)
              .OnDelete(DeleteBehavior.ClientSetNull);





            modelBuilder.Entity<Role>()
                .HasData(

                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" },
                new Role { Id = 3, Name = "Customer" },
                new Role { Id = 4, Name = "Marchent" }


                );




            //One - to - Many Relationships
            modelBuilder.Entity<Car>(entity =>
            {
                //entity.Property(p => p.Display)
                //    .HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'");
                entity.Property(p => p.Display)
                    .HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'", stored: true);

                entity.Property(p => p.IsDrivable)
                     .HasField("_isDrivable")
                     .HasDefaultValue(true);
                entity.HasOne(p => p.MakeNavigation)
                  .WithMany(d => d.Cars)
                  .HasForeignKey(p => p.MakeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Inventory_Makes_MakeId");
            });
            modelBuilder.Entity<Make>(entity =>
            {
                entity.HasMany(p => p.Cars)
                .WithOne(p => p.MakeNavigation)
                .HasForeignKey(p => p.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Makes_MakeId");
            });

            //One - to - One Relationships
            modelBuilder.Entity<Radio>(entity =>
            {
                entity.HasIndex(e => e.CarId, "IX_Radios_CarId")
                    .IsUnique();


                entity.HasOne(p => p.CarNavigation)
                .WithOne(p => p.RadioNavigation)
                .HasForeignKey<Radio>(f => f.CarId);
            });



            modelBuilder.Entity<Car>()
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
}


//Overriding EF Core Conventions
//New in EF Core 6, the conventions can be overridden using the ConfigureConventions() method.For
//example, if you want string properties to default to a certain size (instead of nvarchar(max)), you can add 
//the following code into the ApplicationDbContext class:
