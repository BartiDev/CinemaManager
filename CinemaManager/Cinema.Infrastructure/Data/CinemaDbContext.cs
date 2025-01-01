using System;
using System.Collections.Generic;
using Cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure.Data;

public partial class CinemaDbContext : DbContext
{
    public CinemaDbContext()
    {
    }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:CinemaDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC27D6EA6C0E");

            entity.ToTable("Movie");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Actors)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Awards)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.BoxOffice)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Director)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Genre)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.ImdbRating).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Plot)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Poster)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Rated)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Released)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Runtime)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(512);
            entity.Property(e => e.Writer)
                .HasMaxLength(512)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
