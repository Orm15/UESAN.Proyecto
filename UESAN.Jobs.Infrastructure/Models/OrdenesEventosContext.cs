using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UESAN.Proyecto.Core.entities;
using Stream = UESAN.Proyecto.Core.entities.Stream;

namespace UESAN.proyecto.Infrastructure.Models;

public partial class OrdenesEventosContext : DbContext
{
    public OrdenesEventosContext()
    {
    }

    public OrdenesEventosContext(DbContextOptions<OrdenesEventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Edicion> Edicion { get; set; }

    public virtual DbSet<Eventos> Eventos { get; set; }

    public virtual DbSet<ServicioFotos> ServicioFotos { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Stream> Stream { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Videos> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-U1V4DL6;DataBase=OrdenesEventos;TrustServerCertificate=True;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Edicion>(entity =>
        {
            entity.HasKey(e => e.IdEdicion).HasName("PK__Edicion__8A0A98394D80130A");

            entity.Property(e => e.IdEdicion)
                .ValueGeneratedNever()
                .HasColumnName("idEdicion");
            entity.Property(e => e.Descripción)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("descripción");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.IdVideo).HasColumnName("idVideo");
            entity.Property(e => e.Musica)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdVideoNavigation).WithMany(p => p.EdicionNavigation)
                .HasForeignKey(d => d.IdVideo)
                .HasConstraintName("FK__Edicion__idVideo__300424B4");
        });

        modelBuilder.Entity<Eventos>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Eventos__C8DC7BDA33049AA3");

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
                .HasColumnType("datetime")
                .HasColumnName("fechaEvento");
            entity.Property(e => e.HoraFin)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("horaInicio");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
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

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Eventos__idUsuar__30F848ED");
        });

        modelBuilder.Entity<ServicioFotos>(entity =>
        {
            entity.HasKey(e => e.IdServicioFotos).HasName("PK__Servicio__A49B09EBB61C3515");

            entity.Property(e => e.IdServicioFotos).ValueGeneratedNever();
            entity.Property(e => e.Canales)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.CantidadFotos)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Link)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.PesonaObjetivo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ServicioFotos)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__ServicioF__IdSer__31EC6D26");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdServicios).HasName("PK__Servicio__185EC2A0C96DFBB5");

            entity.Property(e => e.IdServicios).HasColumnName("idServicios");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("estado");
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
                .HasConstraintName("FK__Servicios__idEve__32E0915F");
        });

        modelBuilder.Entity<Stream>(entity =>
        {
            entity.HasKey(e => e.IdStream).HasName("PK__Stream__E1BBB4DF9A047547");

            entity.Property(e => e.IdStream)
                .ValueGeneratedNever()
                .HasColumnName("idStream");
            entity.Property(e => e.IdServicios).HasColumnName("idServicios");

            entity.HasOne(d => d.IdServiciosNavigation).WithMany(p => p.Stream)
                .HasForeignKey(d => d.IdServicios)
                .HasConstraintName("FK__Stream__idServic__33D4B598");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A61DB99A75");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasColumnName("area");
            entity.Property(e => e.Contra)
                .HasMaxLength(50)
                .HasColumnName("contra");
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
            entity.Property(e => e.Salt)
                .HasMaxLength(24)
                .IsFixedLength()
                .HasColumnName("salt");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Videos>(entity =>
        {
            entity.HasKey(e => e.IdVideo).HasName("PK__videos__D2D0AD2A66B15F3E");

            entity.ToTable("videos");

            entity.Property(e => e.IdVideo).HasColumnName("idVideo");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("estado");
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
                .HasConstraintName("FK__videos__idServic__34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
