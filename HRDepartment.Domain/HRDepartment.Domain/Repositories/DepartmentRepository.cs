using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для управления данными отделов.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с отделами.
/// </summary>
public class DepartmentRepository(HRDepartmentContext context) : IRepository<Department> 
{ 

    /// <inheritdoc />
    public IEnumerable<Department> GetAll() => context.Departments.ToList();

    /// <inheritdoc />
    public Department? GetById(int id) => context.Departments.FirstOrDefault(d => d.Id == id);

    /// <inheritdoc />
    public int Post(Department department)
    {
        context.Departments.Add(department);
        context.SaveChanges();
        return department.Id;
    }

    /// <inheritdoc />
    public bool Put(Department department)
    {
        var oldValue = GetById(department.Id);
        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(department);
        context.SaveChanges();

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var department = GetById(id);
        if (department == null)
            return false;

        context.Departments.Remove(department);
        context.SaveChanges();
        return true;
    }
}