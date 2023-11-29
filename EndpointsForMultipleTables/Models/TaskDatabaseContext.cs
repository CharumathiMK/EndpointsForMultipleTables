using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EndpointsForMultipleTables.Models;

public partial class TaskDatabaseContext : DbContext
{
    public TaskDatabaseContext()
    {
    }

    public TaskDatabaseContext(DbContextOptions<TaskDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=CIPL1411DBA\\SQLEXPRESS2019;Database=TaskDatabase;User Id=sa;Password=Colan123;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;Integrated Security=FALSE;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepNo);

            entity.ToTable("Department");

            entity.Property(e => e.DepName).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);

            // Configure the relationship
            entity.HasMany(d => d.Employees)//It uses the HasMany method to specify a one-to-many relationship: one department can have many employees.
           .WithOne(e => e.DepNoNavigation)//WithOne method to indicate that each "Employee" entity has one related "Department
           .HasForeignKey(e => e.DepNo)
           .OnDelete(DeleteBehavior.Cascade);


        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpName).HasMaxLength(50);

            entity.HasOne(d => d.DepNoNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
