using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context;

public partial class WebserviceContext : DbContext
{
    public WebserviceContext()
    {
    }

    public WebserviceContext(DbContextOptions<WebserviceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckCode> CheckCodes { get; set; }

    public virtual DbSet<Contribution> Contributions { get; set; }

    public virtual DbSet<ContributionRole> ContributionRoles { get; set; }

    public virtual DbSet<Datum> Data { get; set; }

    public virtual DbSet<KactusRole> KactusRoles { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConectionString"));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CheckCod__3214EC079015DBF1");

            entity.ToTable("CheckCode", "Process");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Contribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contribu__3214EC0753DE568C");

            entity.ToTable("Contribution", "Configuration");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CostCenter)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Role)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ContributionRole).WithMany(p => p.Contributions)
                .HasForeignKey(d => d.ContributionRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contribut__Contr__46E78A0C");

            entity.HasOne(d => d.Headquarters).WithMany(p => p.Contributions)
                .HasForeignKey(d => d.HeadquartersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contribut__Headq__45F365D3");
        });

        modelBuilder.Entity<ContributionRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contribu__3214EC074779A1A7");

            entity.ToTable("ContributionRole", "Configuration");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.KactusRole).WithMany(p => p.ContributionRoles)
                .HasForeignKey(d => d.KactusRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contribut__Kactu__412EB0B6");
        });

        modelBuilder.Entity<Datum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Data__3214EC07AE32CE71");

            entity.ToTable("Data", "Configuration");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Equivalent)
                .IsUnicode(false)
                .HasColumnName("equivalent");
            entity.Property(e => e.Inheritance).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Data__ParentId__36B12243");

            entity.HasOne(d => d.Table).WithMany(p => p.Data)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Data__TableId__37A5467C");

            entity.HasOne(d => d.User).WithMany(p => p.Data)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Data__UserId__3A81B327");
        });

        modelBuilder.Entity<KactusRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KactusRo__3214EC07AFB6B3F2");

            entity.ToTable("KactusRole", "Configuration");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC07A54AD74E");

            entity.ToTable("Table", "Configuration");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC075C6DD576");

            entity.ToTable("User", "Security");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
