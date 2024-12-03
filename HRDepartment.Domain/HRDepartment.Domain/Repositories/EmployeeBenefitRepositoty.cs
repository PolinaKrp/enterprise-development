using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о льготах сотрудников.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с льготами сотрудников.
/// </summary>

public class EmployeeBenefitRepository(HRDepartmentContext context) : IRepository<EmployeeBenefit> 
{ 

    /// <summary>
    /// Получает все льготы сотрудников.
    /// </summary>
    public IEnumerable<EmployeeBenefit> GetAll() => context.EmployeeBenefits.ToList();

    /// <summary>
    /// Получает льготу сотрудника по указанному идентификатору.
    /// </summary>
    public EmployeeBenefit? GetById(int id) => context.EmployeeBenefits.Find(id);

    /// <summary>
    /// Добавляет новую льготу сотрудника в репозиторий.
    /// </summary>
    public int Post(EmployeeBenefit benefit)
    {
        context.EmployeeBenefits.Add(benefit);
        context.SaveChanges();
        return benefit.Id;
    }

    /// <summary>
    /// Обновляет существующую льготу сотрудника.
    /// </summary>
    public bool Put(EmployeeBenefit benefit)
    {
        var oldValue = GetById(benefit.Id);
        if (oldValue == null)
            return false;

        oldValue.EmployeeId = benefit.EmployeeId;
        oldValue.BenefitTypeId = benefit.BenefitTypeId;
        oldValue.IssueDate = benefit.IssueDate;

        context.EmployeeBenefits.Update(oldValue);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Удаляет льготу сотрудника по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        var benefit = GetById(id);
        if (benefit == null)
            return false;

        context.EmployeeBenefits.Remove(benefit);
        context.SaveChanges();
        return true;
    }
}