using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosVentas.Infrastructure.Persistences.Contexts.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A5A02F28F");

            builder.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
