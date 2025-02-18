using Ecommorce.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
    public class RoleConfigration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> modelBuilder)
        {

            modelBuilder.ToTable("Roles");
            modelBuilder.HasKey(uf => uf.Id);
            modelBuilder
                .HasData(

                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" },
                new Role { Id = 3, Name = "Customer" },
                new Role { Id = 4, Name = "Marchent" }


                );
        }
    }


}
