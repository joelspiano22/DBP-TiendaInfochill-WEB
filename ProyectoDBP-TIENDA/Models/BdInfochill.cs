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

    public virtual DbSet<TbAula> TbAulas { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetalleAula> TbDetalleAulas { get; set; }

    public virtual DbSet<TbDetalleCompra> TbDetalleCompras { get; set; }

    public virtual DbSet<TbDetalleFactura> TbDetalleFacturas { get; set; }

    public virtual DbSet<TbOrdenCompra> TbOrdenCompras { get; set; }

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
            entity.HasKey(e => e.IdAdmin).HasName("PK__TB_ADMIN__B2C3ADE58D48AE96");

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

        modelBuilder.Entity<TbAula>(entity =>
        {
            entity.HasKey(e => e.CodAula).HasName("PK__TB_AULA__3DB71BD8AEF05440");

            entity.ToTable("TB_AULA");

            entity.Property(e => e.CodAula)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_AULA");
            entity.Property(e => e.CursoAula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CURSO_AULA");
            entity.Property(e => e.FechAula)
                .HasColumnType("date")
                .HasColumnName("FECH_AULA");
            entity.Property(e => e.LugarAula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LUGAR_AULA");
            entity.Property(e => e.StkAula).HasColumnName("STK_AULA");
            entity.Property(e => e.UniAula)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UNI_AULA");
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente).HasName("PK__TB_CLIEN__39F43E92D65BF3F9");

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

        modelBuilder.Entity<TbDetalleAula>(entity =>
        {
            entity.HasKey(e => e.CodAula).HasName("PK__TB_DETAL__3DB71BD806337E91");

            entity.ToTable("TB_DETALLE_AULA");

            entity.Property(e => e.CodAula)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_AULA");
            entity.Property(e => e.FechAula)
                .HasColumnType("date")
                .HasColumnName("FECH_AULA");
            entity.Property(e => e.LugarAula)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LUGAR_AULA");

            entity.HasOne(d => d.CodAulaNavigation).WithOne(p => p.TbDetalleAulaCodAulaNavigation)
                .HasForeignKey<TbDetalleAula>(d => d.CodAula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__COD_A__6477ECF3");

            entity.HasOne(d => d.LugarAulaNavigation).WithMany(p => p.TbDetalleAulaLugarAulaNavigations)
                .HasForeignKey(d => d.LugarAula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__LUGAR__656C112C");
        });

        modelBuilder.Entity<TbDetalleCompra>(entity =>
        {
            entity.HasKey(e => new { e.NumOco, e.IdPro }).HasName("PK__TB_DETAL__B40526892624ECE9");

            entity.ToTable("TB_DETALLE_COMPRA");

            entity.Property(e => e.NumOco)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NUM_OCO");
            entity.Property(e => e.IdPro).HasColumnName("idPro");
            entity.Property(e => e.CanPed).HasColumnName("CAN_PED");

            entity.HasOne(d => d.IdProNavigation).WithMany(p => p.TbDetalleCompras)
                .HasForeignKey(d => d.IdPro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__idPro__5FB337D6");

            entity.HasOne(d => d.NumOcoNavigation).WithMany(p => p.TbDetalleCompras)
                .HasForeignKey(d => d.NumOco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__NUM_O__5EBF139D");
        });

        modelBuilder.Entity<TbDetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdPro).HasName("PK__TB_DETAL__3D795B27F08AD2D1");

            entity.ToTable("TB_DETALLE_FACTURA");

            entity.Property(e => e.IdPro)
                .ValueGeneratedNever()
                .HasColumnName("idPro");
            entity.Property(e => e.CanVen).HasColumnName("CAN_VEN");
            entity.Property(e => e.PreVen)
                .HasColumnType("money")
                .HasColumnName("PRE_VEN");

            entity.HasOne(d => d.IdProNavigation).WithOne(p => p.TbDetalleFactura)
                .HasForeignKey<TbDetalleFactura>(d => d.IdPro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__idPro__5BE2A6F2");
        });

        modelBuilder.Entity<TbOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.NumOco).HasName("PK__TB_ORDEN__D7D2B33BCB084355");

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
                .HasConstraintName("FK__TB_ORDEN___codPr__5535A963");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.IdPro).HasName("PK__TB_PRODU__3D795B27EF140A78");

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
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("prePro");
            entity.Property(e => e.StkAct).HasColumnName("stkAct");
            entity.Property(e => e.StkMin).HasColumnName("stkMin");
        });

        modelBuilder.Entity<TbProveedor>(entity =>
        {
            entity.HasKey(e => e.CodProveedor).HasName("PK__TB_PROVE__26E566FBD368C869");

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
            entity
                .HasNoKey()
                .ToTable("TB_USUARIO");

            entity.Property(e => e.CodCliente).HasColumnName("codCliente");
            entity.Property(e => e.ContraUsu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contraUsu");

            entity.HasOne(d => d.CodClienteNavigation).WithMany()
                .HasForeignKey(d => d.CodCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_USUARI__codCl__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
