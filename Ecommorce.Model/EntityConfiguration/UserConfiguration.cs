using Ecommorce.Model.UserModel;
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }


    public class UserFollowConfigration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> modelBuilder)
        {

            modelBuilder
                .HasKey(uf => new { uf.FollowerId, uf.FollowingId });

            modelBuilder
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(u => u.FollowerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
              .HasOne(uf => uf.Following)
              .WithMany(u => u.Followers)
              .HasForeignKey(u => u.FollowingId)
              .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

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
