using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProgramacionWeb_Backend.Models;

public partial class Web24BdContext : DbContext
{
    public Web24BdContext()
    {
    }

    public Web24BdContext(DbContextOptions<Web24BdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Prueba> Pruebas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=FERMAX08; Database=WEB24_BD; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("Persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido).IsUnicode(false);
            entity.Property(e => e.Curp)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.NombrePuesto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rfc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RFC");
        });

        modelBuilder.Entity<Prueba>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Prueba");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
