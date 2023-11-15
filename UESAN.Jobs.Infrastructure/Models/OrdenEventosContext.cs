using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UESAN.Proyecto.Core.entities;

namespace UESAN.proyecto.Infrastructure.Models;

public partial class OrdenEventosContext : DbContext
{
    public OrdenEventosContext()
    {
    }

    public OrdenEventosContext(DbContextOptions<OrdenEventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Eventos> Eventos { get; set; }

    public virtual DbSet<Foto> Foto { get; set; }

    public virtual DbSet<Interaccion> Interaccion { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Videos> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-HP1HJ343\\SOY_YO; DataBase=OrdenEventos;TrustServerCertificate=True;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Eventos>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Eventos__C8DC7BDAA3C05E81");

            entity.Property(e => e.IdEvento).HasColumnName("idEvento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaEvento)
                .HasColumnType("date")
                .HasColumnName("fechaEvento");
            entity.Property(e => e.HoraFin)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("horaInicio");
            entity.Property(e => e.Lugar)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("lugar");
            entity.Property(e => e.MomentosImportantes)
                .HasMaxLength(300)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.IdFoto).HasName("PK__foto__69D65094D0298955");

            entity.ToTable("foto");

            entity.Property(e => e.IdFoto).HasColumnName("idFoto");
            entity.Property(e => e.Canales)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("canales");
            entity.Property(e => e.FechaSubida)
                .HasColumnType("datetime")
                .HasColumnName("fechaSubida");
            entity.Property(e => e.IdServicios).HasColumnName("idServicios");
            entity.Property(e => e.Link)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("link");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("nombre");
            entity.Property(e => e.NombrePersonaObjetivo)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("nombrePersonaObjetivo");
            entity.Property(e => e.TipoFoto)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("tipoFoto");
            entity.Property(e => e.UbicacionFoto)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("ubicacionFoto");

            entity.HasOne(d => d.IdServiciosNavigation).WithMany(p => p.Foto)
                .HasForeignKey(d => d.IdServicios)
                .HasConstraintName("FK__foto__idServicio__2E1BDC42");
        });

        modelBuilder.Entity<Interaccion>(entity =>
        {
            entity.HasKey(e => e.IdInteraccion).HasName("PK__Interacc__ADBFF88308B57243");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("descripcion");
            entity.Property(e => e.IdEvento).HasColumnName("idEvento");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Interaccion)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK__Interacci__idEve__300424B4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Interaccion)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Interacci__idUsu__2F10007B");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdServicios).HasName("PK__Servicio__185EC2A03A05A01C");

            entity.Property(e => e.IdServicios).HasColumnName("idServicios");
            entity.Property(e => e.IdEvento).HasColumnName("idEvento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK__Servicios__idEve__30F848ED");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A657B4C89C");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasColumnName("area");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Videos>(entity =>
        {
            entity.HasKey(e => e.IdVideo).HasName("PK__videos__D2D0AD2A6F876EC5");

            entity.ToTable("videos");

            entity.Property(e => e.IdVideo).HasColumnName("idVideo");
            entity.Property(e => e.FechaSubida)
                .HasColumnType("datetime")
                .HasColumnName("fechaSubida");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Link)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("link");
            entity.Property(e => e.LugarFilmacion)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("lugarFilmacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("nombre");
            entity.Property(e => e.NombreObjetivo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombreObjetivo");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Videos)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__videos__idServic__31EC6D26");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
