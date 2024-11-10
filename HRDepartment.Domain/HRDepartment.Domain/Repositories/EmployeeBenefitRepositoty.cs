using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о льготах сотрудников.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с льготами сотрудников.
/// </summary>
public class EmployeeBenefitRepository : IRepository<EmployeeBenefit>
{
    private readonly List<EmployeeBenefit> employeeBenefits; 

    /// <summary>
    /// Инициализирует новый экземпляр репозитория с заданным списком льгот сотрудников.
    /// </summary>
    public EmployeeBenefitRepository(List<EmployeeBenefit> benefitList)
    {
        employeeBenefits = benefitList;
    }

    /// <summary>
    /// Получает все льготы сотрудников.
    /// </summary>
    public IEnumerable<EmployeeBenefit> GetAll() => employeeBenefits;

    /// <summary>
    /// Получает льготу сотрудника по указанному идентификатору.
    /// </summary>
    public EmployeeBenefit? GetById(int id) => employeeBenefits.FirstOrDefault(b => b.Id == id);

    /// <summary>
    /// Добавляет новую льготу сотрудника в репозиторий.
    /// </summary>
    public int Post(EmployeeBenefit benefit)
    {
        var newId = employeeBenefits.Count > 0 ? employeeBenefits.Max(b => b.Id) + 1 : 1;
        benefit.Id = newId;
        employeeBenefits.Add(benefit);
        return newId;
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
        oldValue.Employee = benefit.Employee;
        oldValue.BenefitTypeId = benefit.BenefitTypeId;
        oldValue.BenefitType = benefit.BenefitType;
        oldValue.IssueDate = benefit.IssueDate;

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

        employeeBenefits.Remove(benefit);
        return true;
    }
}