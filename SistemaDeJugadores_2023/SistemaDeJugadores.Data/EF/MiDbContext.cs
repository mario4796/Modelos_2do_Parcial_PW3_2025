using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeJugadores.Data.EF;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Jugador> Jugadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-241GHB2\\SQLEXPRESS;Database=SistemaJugadoresDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipo__3214EC077C1B9A5E");
        });

        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jugador__3214EC073E06C198");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Jugadors).HasConstraintName("FK_Jugador_Equipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
