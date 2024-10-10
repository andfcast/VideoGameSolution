using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VideoGameApp.Infrastructure.Entidades;

namespace VideoGameApp.Infrastructure.Context;

public partial class VideoGameStoreDbContext : DbContext
{
    public VideoGameStoreDbContext()
    {
    }

    public VideoGameStoreDbContext(DbContextOptions<VideoGameStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Videojuego> Videojuegos { get; set; }
          

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Puntaje).HasColumnType("decimal(2, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CalificacioneIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Usuarios");

            entity.HasOne(d => d.IdUsuarioActualizacionNavigation).WithMany(p => p.CalificacioneIdUsuarioActualizacionNavigations)
                .HasForeignKey(d => d.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Usuarios_Actualizacion");

            entity.HasOne(d => d.IdVideojuegoNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdVideojuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Videojuegos");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Videojuego>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Videojuego");

            entity.Property(e => e.AnioLanzamiento).HasMaxLength(4);
            entity.Property(e => e.Compania).HasMaxLength(50);
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("money");
            entity.Property(e => e.Puntaje).HasColumnType("decimal(2, 2)");

            entity.HasOne(d => d.IdUsuarioActualizacionNavigation).WithMany(p => p.Videojuegos)
                .HasForeignKey(d => d.IdUsuarioActualizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Videojuegos_Usuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
