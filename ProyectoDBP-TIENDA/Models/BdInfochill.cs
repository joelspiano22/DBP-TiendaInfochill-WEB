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

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetalleFactura> TbDetalleFacturas { get; set; }

    public virtual DbSet<TbOrdenCompra> TbOrdenCompras { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbProveedor> TbProveedors { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-AMUJTOVV\\SQLEXPRESS;Initial Catalog=INFOCHILL;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__TB_ADMIN__B2C3ADE5D2F41655");

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

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente).HasName("PK__TB_CLIEN__39F43E92D79BD4A4");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.CodCliente).HasColumnName("codCliente");
            entity.Property(e => e.ApeCli)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apeCli");
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
            entity.Property(e => e.Estado).HasColumnName("estado");
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

        modelBuilder.Entity<TbDetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdFac).HasName("PK__TB_DETAL__39C0459A98B7E659");

            entity.ToTable("TB_DETALLE_FACTURA");

            entity.Property(e => e.IdFac).HasColumnName("idFac");
            entity.Property(e => e.CanVen).HasColumnName("CAN_VEN");
            entity.Property(e => e.CodCliente).HasColumnName("codCliente");
            entity.Property(e => e.CodUsu).HasColumnName("codUsu");
            entity.Property(e => e.IdPro).HasColumnName("idPro");
            entity.Property(e => e.PreVen)
                .HasColumnType("money")
                .HasColumnName("PRE_VEN");

            entity.HasOne(d => d.CodClienteNavigation).WithMany(p => p.TbDetalleFacturas)
                .HasForeignKey(d => d.CodCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__codCl__49C3F6B7");

            entity.HasOne(d => d.CodUsuNavigation).WithMany(p => p.TbDetalleFacturas)
                .HasForeignKey(d => d.CodUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__codUs__47DBAE45");

            entity.HasOne(d => d.IdProNavigation).WithMany(p => p.TbDetalleFacturas)
                .HasForeignKey(d => d.IdPro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__idPro__48CFD27E");
        });

        modelBuilder.Entity<TbOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.NumOco).HasName("PK__TB_ORDEN__D7D2B33BA3A70CDA");

            entity.ToTable("TB_ORDEN_COMPRA");

            entity.Property(e => e.NumOco)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NUM_OCO");
            entity.Property(e => e.CodProveedor).HasColumnName("codProveedor");
            entity.Property(e => e.EstOco)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EST_OCO");
            entity.Property(e => e.FecAte)
                .HasColumnType("date")
                .HasColumnName("FEC_ATE");
            entity.Property(e => e.FecOco)
                .HasColumnType("date")
                .HasColumnName("FEC_OCO");

            entity.HasOne(d => d.CodProveedorNavigation).WithMany(p => p.TbOrdenCompras)
                .HasForeignKey(d => d.CodProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_ORDEN___codPr__3F466844");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.IdPro).HasName("PK__TB_PRODU__3D795B27D871C4BF");

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
            entity.HasKey(e => e.CodProveedor).HasName("PK__TB_PROVE__26E566FB6BA8BCF6");

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
            entity.HasKey(e => e.CodUsu).HasName("PK__TB_USUAR__9B805881B3B73C9A");

            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.CodUsu).HasColumnName("codUsu");
            entity.Property(e => e.ContraUsu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contraUsu");
            entity.Property(e => e.IdUsu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idUsu");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
