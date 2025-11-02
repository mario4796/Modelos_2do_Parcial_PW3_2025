using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Pilotos_Escuderias_2024.Data.EF;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Escuderium> Escuderia { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-241GHB2\\SQLEXPRESS;Database=Formula1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Escuderium>(entity =>
        {
            entity.HasKey(e => e.IdEscuderia).HasName("PK__Escuderi__E948A0DC12C3156B");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto).HasName("PK__Piloto__DB35379F7FBAE474");

            entity.HasOne(d => d.IdEscuderiaNavigation).WithMany(p => p.Pilotos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Piloto_Escuderia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
