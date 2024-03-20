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

    public virtual DbSet<CircuitoCerrado> CircuitoCerrado { get; set; }

    public virtual DbSet<Edicion> Edicion { get; set; }

    public virtual DbSet<EscenasVideo> EscenasVideo { get; set; }

    public virtual DbSet<Eventos> Eventos { get; set; }

    public virtual DbSet<ServicioEdicionVideo> ServicioEdicionVideo { get; set; }

    public virtual DbSet<ServicioFotos> ServicioFotos { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Stream> Stream { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Videos> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-HP1HJ343\\SOY_YO;DataBase=OrdenesEventos;TrustServerCertificate=True;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<CircuitoCerrado>(entity =>
        {
            entity.HasKey(e => e.IdCircuitoCerrado).HasName("PK__Circuito__2144FF1F5B8733E8");

            entity.Property(e => e.Angulos)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Guardar)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Link)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.NumeroAngulos)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NumeroCamaras)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.CircuitoCerrado)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__CircuitoC__idSer__35BCFE0A");
        });

        modelBuilder.Entity<Edicion>(entity =>
        {
            entity.HasKey(e => e.IdEdicion).HasName("PK__Edicion__8A0A9839AE2A5072");

            entity.Property(e => e.IdEdicion).HasColumnName("idEdicion");
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
                .HasConstraintName("FK__Edicion__idVideo__36B12243");
        });

        modelBuilder.Entity<EscenasVideo>(entity =>
        {
            entity.HasKey(e => e.IdEscena).HasName("PK__EscenasV__BED662CAFF565185");

            entity.Property(e => e.IdEscena).HasColumnName("idEscena");
            entity.Property(e => e.Cambios)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.DescripcionEscena)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.IdServicioEdicionVideo).HasColumnName("idServicioEdicionVideo");
            entity.Property(e => e.IdVideo).HasColumnName("idVideo");
            entity.Property(e => e.LinkVideo)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("linkVideo");
            entity.Property(e => e.NombreEscena)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombreEscena");
            entity.Property(e => e.NombreVideo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombreVideo");
            entity.Property(e => e.Tiempo)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("tiempo");

            entity.HasOne(d => d.IdServicioEdicionVideoNavigation).WithMany(p => p.EscenasVideo)
                .HasForeignKey(d => d.IdServicioEdicionVideo)
                .HasConstraintName("FK__EscenasVi__idSer__37A5467C");

            entity.HasOne(d => d.IdVideoNavigation).WithMany(p => p.EscenasVideo)
                .HasForeignKey(d => d.IdVideo)
                .HasConstraintName("FK__EscenasVi__idVid__38996AB5");
        });

        modelBuilder.Entity<Eventos>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Eventos__C8DC7BDA071ABC8C");

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
                .HasConstraintName("FK__Eventos__idUsuar__398D8EEE");
        });

        modelBuilder.Entity<ServicioEdicionVideo>(entity =>
        {
            entity.HasKey(e => e.IdServicioEdicionVideo).HasName("PK__Servicio__62C318040EADB0A4");

            entity.Property(e => e.IdServicioEdicionVideo).HasColumnName("idServicioEdicionVideo");
            entity.Property(e => e.CarreraCargoEmpresa)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Destino)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.DuracionVideo)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.FormatoVideo)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.IdEvento).HasColumnName("idEvento");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Logos)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Musica)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.NombreEntrevistado)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Objetivo)
                .HasMaxLength(80)
                .IsFixedLength();

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.ServicioEdicionVideo)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK__ServicioE__idEve__3A81B327");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ServicioEdicionVideo)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__ServicioE__idUsu__3B75D760");
        });

        modelBuilder.Entity<ServicioFotos>(entity =>
        {
            entity.HasKey(e => e.IdServicioFotos).HasName("PK__Servicio__A49B09EBC5147A6E");

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
                .HasConstraintName("FK__ServicioF__IdSer__3C69FB99");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdServicios).HasName("PK__Servicio__185EC2A0F5CF4D88");

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
                .HasConstraintName("FK__Servicios__idEve__3D5E1FD2");
        });

        modelBuilder.Entity<Stream>(entity =>
        {
            entity.HasKey(e => e.IdStream).HasName("PK__Stream__E1BBB4DFAD2DF475");

            entity.Property(e => e.IdStream).HasColumnName("idStream");
            entity.Property(e => e.Angulo)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ContactoCuenta)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Contacto_Cuenta");
            entity.Property(e => e.Cuenta)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IdServicios).HasColumnName("idServicios");
            entity.Property(e => e.NumCam).HasColumnName("Num_Cam");
            entity.Property(e => e.Plataforma)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.IdServiciosNavigation).WithMany(p => p.Stream)
                .HasForeignKey(d => d.IdServicios)
                .HasConstraintName("FK__Stream__idServic__3E52440B");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A6C5CFE36B");

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
            entity.HasKey(e => e.IdVideo).HasName("PK__videos__D2D0AD2A3D713306");

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
                .HasConstraintName("FK__videos__idServic__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
