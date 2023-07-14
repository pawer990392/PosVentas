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
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(e => e.SaleId).HasName("PK__Sales__1EE3C3FFC43A8A16");

            builder.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Client).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Sales__ClientId__6C190EBB");

            builder.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sales__UserId__6D0D32F4");
        }
    }
}
