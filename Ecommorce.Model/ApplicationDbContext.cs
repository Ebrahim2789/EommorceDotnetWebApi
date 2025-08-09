using Ecommorce.Model.Model;
using Microsoft.EntityFrameworkCore;
using Ecommorce.Model.UserModel;
using Ecommorce.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Ecommorce.Model.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ecommorce.Model.ProductModels;
using Ecommorce.Model.NewFolder;
using Ecommorce.Model.OrderModels;

namespace Ecommorce.Model
{
    public class ApplicationDbContext :DbContext
        //IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        //public class ApplicationDbContext: IdentityDbContext< ApplicationUser, ApplicationRole, string IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>   IdentityRoleClaim<string>, IdentityUserToken<string>>
        //    public class ApplicationDbContext : IdentityDbContext< ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
        //{
        public DbSet<Car> Cars { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarDriver> CarsToDrivers { get; set; }

        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        //public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //public DbSet<ApplicationRole> ApplicationRole { get; set; }
        //public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        //public DbSet<ApplicationUserClaim> ApplicationUserClaim { get; set; }
        //public DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }
        //public DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }
        //public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }
        public DbSet<CoreMenu> coreMenus { get; set; }
        public DbSet<CoreRoleMenu> coreRoleMenus { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductMedia> ProductMedias { get; set; }



        public DbSet<ProductOption> ProductOptions { get; set; }

        public DbSet<ProductOptionData> ProductOptionDatas { get; set; }

        public DbSet<ProductOptionValue> ProductOptionValues { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeData> ProductAttributeDatas { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }


        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Category> Category { get; set; }



        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<OrderAddress> OrderAddress { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new ProductConfigration());
            modelBuilder.ApplyConfiguration(new ProductVariationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());


            modelBuilder.ApplyConfiguration(new ProductMediaConfiguration());

           modelBuilder.ApplyConfiguration(new ProductAtributeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductAtributeDataConfiguration());
            modelBuilder.ApplyConfiguration(new ProductAtributeValueConfiguration());

            modelBuilder.ApplyConfiguration(new ProductOptionDataConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOptionValueConfiguration());



            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new UserFollowConfigration());
            modelBuilder.ApplyConfiguration(new RoleConfigration());

            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new RoleMenuConfiguration());


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OthersConfiguration());
            modelBuilder.ApplyConfiguration(new MakeConfiguration());
            modelBuilder.ApplyConfiguration(new RadioConfiguration());


            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());
            modelBuilder.ApplyConfiguration(new OrderAddressConfiguration());

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });







            //modelBuilder.Entity<ApplicationUser>(entity =>
            //{
            //    entity.ToTable(name: "User");

            //});
            //modelBuilder.Entity<IdentityRole>(entity =>
            //{
            //    entity.ToTable(name: "Role");
            //});
            //modelBuilder.Entity<ApplicationUserRole>(entity =>
            //{
            //    entity.ToTable(name: "UserRoles"); ;
            //});
            //modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            //{
            //    entity.ToTable("UserClaims");
            //});
            //modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            //{
            //    entity.ToTable("UserLogins");
            //    //in case you chagned the TKey type  
            //    //  entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });         
            //});
            //modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            //{
            //    entity.ToTable("RoleClaims");
            //});
            //modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            //{
            //    entity.ToTable("UserTokens");
            //    //in case you chagned the TKey type  
            //    // entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });  
            //});

        }



    }

}
//Overriding EF Core Conventions
//New in EF Core 6, the conventions can be overridden using the ConfigureConventions() method.For
//example, if you want string properties to default to a certain size (instead of nvarchar(max)), you can add 
//the following code into the ApplicationDbContext class:
