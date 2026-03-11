using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UMS.DataAccess;

namespace UMS.DataAccess.Context;

public partial class UniversityDbContext : DbContext
{
    public UniversityDbContext()
    {
    }

    public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=UniversityManagementDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.PkCourseId).HasName("PK__Course__C363BB66589568FB");

            entity.Property(e => e.CourseName).IsFixedLength();

            entity.HasOne(d => d.FkDepartmen).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Course_ToDepartment");
        });

        modelBuilder.Entity<CourseAssignment>(entity =>
        {
            entity.HasKey(e => e.PkAssignmentId).HasName("PK__CourseAs__D533D5D6FECD1E04");

            entity.HasOne(d => d.FkCourse).WithMany(p => p.CourseAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseAssignment_Course");

            entity.HasOne(d => d.FkTeacher).WithMany(p => p.CourseAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseAssignment_Teacher");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.PkDepartmentId).HasName("PK__Departme__4E6D01DF0411A9E5");

            entity.Property(e => e.DepartmentName).IsFixedLength();
            entity.Property(e => e.Location).IsFixedLength();
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.PkEnrollmentId).HasName("PK__Enrollme__544932248D76B0E0");

            entity.Property(e => e.Grade).IsFixedLength();
            entity.Property(e => e.Semester).IsFixedLength();

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollment_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollment_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.PkStudentId).HasName("PK__Student__DA018ED3C092A149");

            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.StudentName).IsFixedLength();

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Department");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.PkTeacherId).HasName("PK__Teacher__659BA95448DBC9BE");

            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();

            entity.HasOne(d => d.FkDepartment).WithMany(p => p.Teachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
