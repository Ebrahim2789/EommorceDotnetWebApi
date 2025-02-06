using Ecommorce.Model.Model;
using Microsoft.EntityFrameworkCore;
using Ecommorce.Model.UserModel;
using Ecommorce.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Ecommorce.Model.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using Ecommorce.Model.ProductModels;

namespace Ecommorce.Model
{
    public class ApplicationDbContext : IdentityDbContext<UsersIdentity, RoleIdentity, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(50);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new ProductConfigration());

            modelBuilder.ApplyConfiguration(new ProductMediaConfigrution());

            modelBuilder.ApplyConfiguration(new ProductAtributeDataConfiguration());
            modelBuilder.ApplyConfiguration(new ProductAtributeValueConfiguration());

            modelBuilder.ApplyConfiguration(new ProductOptionDataConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOptionValueConfiguration());

            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new UserFollowConfigration());
            modelBuilder.ApplyConfiguration(new RoleConfigration());


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OthersConfiguration());
            modelBuilder.ApplyConfiguration(new MakeConfiguration());
            modelBuilder.ApplyConfiguration(new RadioConfiguration());

            base.OnModelCreating(modelBuilder);
        
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer();
        //}

        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarDriver> CarsToDrivers { get; set; }

        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }

        public DbSet<UsersIdentity> usersIdentities { get; set; }
        public DbSet<RoleIdentity> roleIdentities { get; set; }

        public DbSet<Product> Products {  get; set; }

        public DbSet< ProductBrand> ProductBrands { get; set; }

        public DbSet< ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductMedia> ProductMedias {  get; set; }

        public DbSet<ProductPublish> ProductPublishes { get; set; }

        public DbSet<ProductOption> ProductOptions { get; set; }

        public DbSet< ProductOptionData> ProductOptionDatas { get; set; }

        public DbSet<ProductOptionValue> ProductOptionValues { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeData> ProductAttributeDatas { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

    }

}
//Overriding EF Core Conventions
//New in EF Core 6, the conventions can be overridden using the ConfigureConventions() method.For
//example, if you want string properties to default to a certain size (instead of nvarchar(max)), you can add 
//the following code into the ApplicationDbContext class:
