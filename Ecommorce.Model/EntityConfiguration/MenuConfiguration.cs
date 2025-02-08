using Ecommorce.Model.NewFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.EntityConfiguration
{
    public class MenuConfiguration : IEntityTypeConfiguration<CoreMenu>
    {
        public void Configure(EntityTypeBuilder<CoreMenu> builder)
        {
            builder.HasKey(m=>m.Id);

            builder.HasOne(m=>m.CoreMenus).WithMany().HasForeignKey(m=>m.ParentId).OnDelete(DeleteBehavior.NoAction);


        }
       
    }


    public class RoleMenuConfiguration : IEntityTypeConfiguration<CoreRoleMenu>
    {
        public void Configure(EntityTypeBuilder<CoreRoleMenu> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Role)
                .WithMany(m => m.RoleMenus)
                .HasForeignKey(m => m.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(m => m.Menu)
                .WithMany()
                .HasForeignKey(m => m.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
