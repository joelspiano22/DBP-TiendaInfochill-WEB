using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDBP_TIENDA.Models;

public partial class BdInfochill : DbContext
{
    public BdInfochill()
    {
    }

    public BdInfochill(DbContextOptions<BdInfochill> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdmin> TbAdmins { get; set; }

    public virtual DbSet<TbDetalleFactura> TbDetalleFacturas { get; set; }

    public virtual DbSet<TbFactura> TbFacturas { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbProveedor> TbProveedors { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JOELSPI\\SQLEXPRESS;Initial Catalog=INFOCHILL;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__TB_ADMIN__B2C3ADE51C17AD23");

            entity.ToTable("TB_ADMIN");

            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.CodAdmin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codAdmin");
            entity.Property(e => e.PassAdmin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("passAdmin");
        });

        modelBuilder.Entity<TbDetalleFactura>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_DETALLE_FACTURA");

            entity.Property(e => e.CanVen).HasColumnName("CAN_VEN");
            entity.Property(e => e.IdFac).HasColumnName("idFac");
            entity.Property(e => e.IdPro).HasColumnName("idPro");
            entity.Property(e => e.PreVen)
                .HasColumnType("money")
                .HasColumnName("PRE_VEN");

            entity.HasOne(d => d.IdFacNavigation).WithMany()
                .HasForeignKey(d => d.IdFac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__idFac__534D60F1");

            entity.HasOne(d => d.IdProNavigation).WithMany()
                .HasForeignKey(d => d.IdPro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__idPro__5441852A");
        });

        modelBuilder.Entity<TbFactura>(entity =>
        {
            entity.HasKey(e => e.IdFac).HasName("PK__TB_FACTU__39C0459A6BBA846D");

            entity.ToTable("TB_FACTURA");

            entity.Property(e => e.IdFac).HasColumnName("idFac");
            entity.Property(e => e.CodUsu).HasColumnName("codUsu");
            entity.Property(e => e.FechaReg)
                .HasColumnType("date")
                .HasColumnName("fechaReg");

            entity.HasOne(d => d.CodUsuNavigation).WithMany(p => p.TbFacturas)
                .HasForeignKey(d => d.CodUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_FACTUR__codUs__5165187F");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.IdPro).HasName("PK__TB_PRODU__3D795B27888A447C");

            entity.ToTable("TB_PRODUCTO");

            entity.Property(e => e.IdPro).HasColumnName("idPro");
            entity.Property(e => e.CatePro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("catePro");
            entity.Property(e => e.DesPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("desPro");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("prePro");
            entity.Property(e => e.StkAct).HasColumnName("stkAct");
            entity.Property(e => e.StkMin).HasColumnName("stkMin");
        });

        modelBuilder.Entity<TbProveedor>(entity =>
        {
            entity.HasKey(e => e.CodProveedor).HasName("PK__TB_PROVE__26E566FB5612E6FF");

            entity.ToTable("TB_PROVEEDOR");

            entity.Property(e => e.CodProveedor).HasColumnName("codProveedor");
            entity.Property(e => e.DirProveedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dirProveedor");
            entity.Property(e => e.RazSocial)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("razSocial");
            entity.Property(e => e.RepVenta)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("repVenta");
            entity.Property(e => e.TlfProveedor)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tlfProveedor");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.CodUsu).HasName("PK__TB_USUAR__9B80588181CFC947");

            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.CodUsu).HasColumnName("codUsu");
            entity.Property(e => e.ApeCli)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apeCli");
            entity.Property(e => e.ContraUsu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contraUsu");
            entity.Property(e => e.CorreoCli)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("correoCli");
            entity.Property(e => e.DniCli)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dniCli");
            entity.Property(e => e.IdUsu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idUsu");
            entity.Property(e => e.NomCli)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nomCli");
            entity.Property(e => e.TlfCli)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tlfCli");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
