using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartementLocation> DepartementLocations { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<WorkInRelatioship> WorkInRelatioships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-PLTUE3E\\SQLEXPRESS;database=company;integrated security=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartementLocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("departement_locations");

            entity.Property(e => e.Locationn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("locationn");

            entity.HasOne(d => d.DnumNavigation).WithMany()
                .HasForeignKey(d => d.Dnum)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Dnum");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Dnum).HasName("PK__departme__7A775085D233B270");

            entity.ToTable("department");

            entity.Property(e => e.Dnum).ValueGeneratedNever();
            entity.Property(e => e.Dname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmpSsn).HasColumnName("emp_ssn");

            entity.HasOne(d => d.EmpSsnNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.EmpSsn)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_emp_ssn");
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasKey(e => e.Namee).HasName("PK__dependen__F0B62891C498C896");

            entity.ToTable("dependents");

            entity.Property(e => e.Namee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("namee");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.EmpSsn).HasColumnName("emp_ssn");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");

            entity.HasOne(d => d.EmpSsnNavigation).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.EmpSsn)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_employee_ssn");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Ssn).HasName("PK__employee__DDDF0AE7C5E3BA9E");

            entity.ToTable("employee");

            entity.Property(e => e.Ssn)
                .ValueGeneratedNever()
                .HasColumnName("ssn");
            entity.Property(e => e.BirthDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("birth_date");
            entity.Property(e => e.Dnum).HasColumnName("dnum");
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.SuperId).HasColumnName("super_id");

            entity.HasOne(d => d.DnumNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Dnum)
                .HasConstraintName("fk_dnumbber");

            entity.HasOne(d => d.Super).WithMany(p => p.InverseSuper)
                .HasForeignKey(d => d.SuperId)
                .HasConstraintName("fk_super_id");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Pnumber).HasName("PK__project__0E0FD1FBCD857C6F");

            entity.ToTable("project");

            entity.Property(e => e.Pnumber)
                .ValueGeneratedNever()
                .HasColumnName("pnumber");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Locationn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("locationn");
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pname");

            entity.HasOne(d => d.DnumNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.Dnum)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Dnumber");
        });

        modelBuilder.Entity<WorkInRelatioship>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("work_in_relatioship");

            entity.Property(e => e.EmpSsn).HasColumnName("emp_ssn");
            entity.Property(e => e.ProjectPnum).HasColumnName("project_pnum");
            entity.Property(e => e.WorkingHours).HasColumnName("working_hours");

            entity.HasOne(d => d.EmpSsnNavigation).WithMany()
                .HasForeignKey(d => d.EmpSsn)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_employeee_ssn");

            entity.HasOne(d => d.ProjectPnumNavigation).WithMany()
                .HasForeignKey(d => d.ProjectPnum)
                .HasConstraintName("fk_project_pnum");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
