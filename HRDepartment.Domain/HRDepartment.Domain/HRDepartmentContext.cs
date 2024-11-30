using HRDepartment.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HRDepartment.Domain;

/// <summary>
/// Контекст базы данных для отдела кадров
/// </summary>
public class HRDepartmentContext(DbContextOptions<HRDepartmentContext> options) : DbContext(options)
{
    /// <summary>
    /// Таблица сотрудников
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Таблица должностей
    /// </summary>
    public DbSet<Position> Positions { get; set; }

    /// <summary>
    /// Таблица отделов
    /// </summary>
    public DbSet<Department> Departments { get; set; } 

    /// <summary>
    /// Таблица цехов
    /// </summary>
    public DbSet<Workshop> Workshops { get; set; }

    /// <summary>
    /// Таблица связей между сотрудниками и должностями
    /// </summary>
    public DbSet<EmployeePosition> EmployeePositions { get; set; }

    /// <summary>
    /// Таблица типов льгот
    /// </summary>
    public DbSet<BenefitType> BenefitTypes { get; set; } 

    /// <summary>
    /// Таблица льгот сотрудников
    /// </summary>
    public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; } 

    /// <summary>
    /// Переопределение метода для установления отношений между таблицами
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка отношений для EmployeePosition
        modelBuilder.Entity<EmployeePosition>()
            .HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeePositions)
            .HasForeignKey(ep => ep.EmployeeId);

        modelBuilder.Entity<EmployeePosition>()
            .HasOne(ep => ep.Position)
            .WithMany(p => p.EmployeePositions)
            .HasForeignKey(ep => ep.PositionId);

        // Настройка отношений для Position и Department
        modelBuilder.Entity<Position>()
            .HasOne(p => p.Department)
            .WithMany(d => d.Positions)
            .HasForeignKey(p => p.DepartmentId);

        // Настройка отношений для Workshop и Employee
        modelBuilder.Entity<Workshop>()
            .HasMany(w => w.Employees)
            .WithOne(e => e.Workshop) 
            .HasForeignKey(e => e.WorkshopId); 

        // Настройка отношений для EmployeeBenefit
        modelBuilder.Entity<EmployeeBenefit>()
            .HasOne(eb => eb.Employee)
            .WithMany(e => e.EmployeeBenefits)
            .HasForeignKey(eb => eb.EmployeeId);

        modelBuilder.Entity<EmployeeBenefit>()
            .HasOne(eb => eb.BenefitType)
            .WithMany(bt => bt.EmployeeBenefits)
            .HasForeignKey(eb => eb.BenefitTypeId);
    }
}