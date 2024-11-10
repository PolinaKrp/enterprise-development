using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными сотрудников.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с данными сотрудников.
/// </summary>
public class EmployeeRepository : IRepository<Employee>
{
    private readonly List<Employee> employees; 

    /// <summary>
    /// Инициализирует новый экземпляр репозитория с заданным списком сотрудников.
    /// </summary>
    public EmployeeRepository(List<Employee> employeeList)
    {
        employees = employeeList;
    }

    /// <summary>
    /// Получает всех сотрудников.
    /// </summary>
    public IEnumerable<Employee> GetAll() => employees;

    /// <summary>
    /// Получает сотрудника по указанному идентификатору.
    /// </summary>
    public Employee? GetById(int id) => employees.FirstOrDefault(e => e.Id == id);

    /// <summary>
    /// Добавляет нового сотрудника в репозиторий.
    /// </summary>
    public int Post(Employee employee)
    {
        var newId = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
        employee.Id = newId;
        employees.Add(employee);
        return newId;
    }

    /// <summary>
    /// Обновляет существующего сотрудника.
    /// </summary>
    public bool Put(Employee employee)
    {
        var oldValue = GetById(employee.Id);
        if (oldValue == null)
            return false;

        oldValue.RegNumber = employee.RegNumber;
        oldValue.FirstName = employee.FirstName;
        oldValue.LastName = employee.LastName;
        oldValue.Patronymic = employee.Patronymic;
        oldValue.BirthDate = employee.BirthDate;
        oldValue.WorkshopId = employee.WorkshopId;
        oldValue.WorkPhoneNumber = employee.WorkPhoneNumber;
        oldValue.PersonalPhoneNumber = employee.PersonalPhoneNumber;
        oldValue.Address = employee.Address;
        oldValue.FamilyMembersCount = employee.FamilyMembersCount;
        oldValue.ChildrenCount = employee.ChildrenCount;
        oldValue.MaritalStatus = employee.MaritalStatus;
        oldValue.EmployeePositions = employee.EmployeePositions;
        oldValue.EmployeeBenefits = employee.EmployeeBenefits;

        return true;
    }

    /// <summary>
    /// Удаляет сотрудника по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        var employee = GetById(id);
        if (employee == null)
            return false;

        employees.Remove(employee);
        return true;
    }
}