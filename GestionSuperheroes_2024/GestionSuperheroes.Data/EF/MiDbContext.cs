using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionSuperheroes.Data.EF;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Superheroe> Superheroes { get; set; }

    public virtual DbSet<Universo> Universos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-241GHB2\\SQLEXPRESS;Database=SuperheroesDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Superheroe>(entity =>
        {
            entity.HasKey(e => e.IdSuperheroe).HasName("PK__Superher__11BA23C9C9D31F29");

            entity.HasOne(d => d.IdUniversoNavigation).WithMany(p => p.Superheroes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Superheroe_Universo");
        });

        modelBuilder.Entity<Universo>(entity =>
        {
            entity.HasKey(e => e.IdUniverso).HasName("PK__Universo__B3080941940C4AB0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
