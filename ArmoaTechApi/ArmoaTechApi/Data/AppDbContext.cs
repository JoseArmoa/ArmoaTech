using System;
using System.Collections.Generic;
using ArmoaTechApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmoaTechApi.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Observaciones> Observaciones { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Reparaciones> Reparaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=ArmoaTech;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C73B2F5D6");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarcas).HasName("PK__Marcas__CB0378C594450E6F");

            entity.Property(e => e.IdMarcas).HasColumnName("idMarcas");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Observaciones>(entity =>
        {
            entity.HasKey(e => e.IdObservacion).HasName("PK__Observac__2A0C01A8A1B2C8EA");

            entity.Property(e => e.IdObservacion).HasColumnName("idObservacion");
            entity.Property(e => e.CodReparacion)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("codReparacion");
            entity.Property(e => e.Detalle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Imgurl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imgurl");

            entity.HasOne(d => d.CodReparacionNavigation).WithMany(p => p.Observaciones)
                .HasForeignKey(d => d.CodReparacion)
                .HasConstraintName("FK__Observaci__codRe__30F848ED");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodProducto).HasName("PK_Producto");

            entity.Property(e => e.CodProducto)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("codProducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.Imageurl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imageurl");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Productos__idCat__286302EC");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK__Productos__idMar__29572725");
        });

        modelBuilder.Entity<Reparaciones>(entity =>
        {
            entity.HasKey(e => e.CodReparacion).HasName("PK__Reparaci__C550D7ACCE8F90FC");

            entity.Property(e => e.CodReparacion)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("codReparacion");
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailCliente");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaIngreso).HasColumnName("fechaIngreso");
            entity.Property(e => e.FechaRetiro).HasColumnName("fechaRetiro");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");
            entity.Property(e => e.Servicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("servicio");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
