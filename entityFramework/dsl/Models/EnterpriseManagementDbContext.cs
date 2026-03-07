using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dsl.Models;

public partial class EnterpriseManagementDbContext : DbContext
{
    public EnterpriseManagementDbContext()
    {
    }

    public EnterpriseManagementDbContext(DbContextOptions<EnterpriseManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=EnterpriseManagementDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07821D5B86");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("department");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("lastName");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
