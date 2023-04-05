using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCPractice1.models;

public partial class MvcpracticeContext : DbContext
{
    public MvcpracticeContext()
    {
    }

    public MvcpracticeContext(DbContextOptions<MvcpracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Passenger> Passengers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=localhost; database=MVCPractice; trusted_connection=true; trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.Seat).HasName("PK__Passenge__A228CA2AED60B45D");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
