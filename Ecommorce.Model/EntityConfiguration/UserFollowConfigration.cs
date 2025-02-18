using Ecommorce.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommorce.Model.EntityConfiguration
{
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


}
