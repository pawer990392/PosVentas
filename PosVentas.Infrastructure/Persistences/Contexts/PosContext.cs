using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PosVentas.Domain.Entities;

public partial class PosContext : DbContext
{
    public PosContext()
    {
    }

    public PosContext(DbContextOptions<PosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BranchOffice> BranchOffices { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRole> MenuRoles { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Purcharse> Purcharses { get; set; }

    public virtual DbSet<PurcharseDetail> PurcharseDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UsersBranchOffice> UsersBranchOffices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=POS;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BranchOffice>(entity =>
        {
           
        });

        modelBuilder.Entity<Business>(entity =>
        {
            
        });

        modelBuilder.Entity<Category>(entity =>
        {
           
        });

        modelBuilder.Entity<Client>(entity =>
        {
            
        });

        modelBuilder.Entity<Department>(entity =>
        {
            
        });

        modelBuilder.Entity<District>(entity =>
        {
            
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            
        });

        modelBuilder.Entity<MenuRole>(entity =>
        {
            
        });

        modelBuilder.Entity<Product>(entity =>
        {
            
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__Provider__B54C687D8B38FFE5");

            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Providers)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Providers__Docum__6477ECF3");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PK__Province__FD0A6F83C2970A74");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Provinces)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Provinces__Depar__656C112C");
        });

        modelBuilder.Entity<Purcharse>(entity =>
        {
            entity.HasKey(e => e.PurcharseId).HasName("PK__Purchars__A98C674B4BA2E2B1");

            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Provider).WithMany(p => p.Purcharses)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__Purcharse__Provi__68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.Purcharses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Purcharse__UserI__693CA210");
        });

        modelBuilder.Entity<PurcharseDetail>(entity =>
        {
            entity.HasKey(e => e.PurcharseDetailId).HasName("PK__Purchars__7353248B1E5C6B02");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Purcharse__Produ__66603565");

            entity.HasOne(d => d.Purcharse).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.PurcharseId)
                .HasConstraintName("FK__Purcharse__Purch__6754599E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A5A02F28F");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__1EE3C3FFC43A8A16");

            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Sales__ClientId__6C190EBB");

            entity.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sales__UserId__6D0D32F4");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK__SaleDeta__70DB14FE8BE44E15");

            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SaleDetai__Produ__6A30C649");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SaleDetai__SaleI__6B24EA82");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CAB73A737");

            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A35C4F1EDF9");

            entity.HasOne(d => d.BranchOffice).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.BranchOfficeId)
                .HasConstraintName("FK__UserRoles__Branc__6E01572D");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoles__RoleI__6EF57B66");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoles__UserI__6FE99F9F");
        });

        modelBuilder.Entity<UsersBranchOffice>(entity =>
        {
            entity.HasKey(e => e.UserBranchOfficeId).HasName("PK__UsersBra__7D1E804AC77949CB");

            entity.HasOne(d => d.BranchOffice).WithMany(p => p.UsersBranchOffices)
                .HasForeignKey(d => d.BranchOfficeId)
                .HasConstraintName("FK__UsersBran__Branc__70DDC3D8");

            entity.HasOne(d => d.User).WithMany(p => p.UsersBranchOffices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UsersBran__UserI__71D1E811");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
