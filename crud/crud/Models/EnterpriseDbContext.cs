using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace crud.Models;

public partial class EnterpriseDbContext : DbContext
{
    public EnterpriseDbContext()
    {
    }

    public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=EnterpriseManagementDB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07821D5B86");

            entity.Property(e => e.Department).IsFixedLength();
            entity.Property(e => e.FirstName).IsFixedLength();
            entity.Property(e => e.LastName).IsFixedLength();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC074E1C9FF6");

            entity.Property(e => e.Sname).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
