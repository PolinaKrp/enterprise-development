using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о позициях сотрудников.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с позициями сотрудников.
/// </summary>
public class EmployeePositionRepository : IRepository<EmployeePosition>
{
    private readonly List<EmployeePosition> employeePositions; 

    /// <summary>
    /// Инициализирует новый экземпляр репозитория с заданным списком позиций сотрудников.
    /// </summary>
    public EmployeePositionRepository(List<EmployeePosition> positionList)
    {
        employeePositions = positionList;
    }

    /// <summary>
    /// Получает все позиции сотрудников.
    /// </summary>
    public IEnumerable<EmployeePosition> GetAll() => employeePositions;

    /// <summary>
    /// Получает позицию сотрудника по указанному идентификатору.
    /// </summary>
    public EmployeePosition? GetById(int id) => employeePositions.FirstOrDefault(p => p.Id == id);

    /// <summary>
    /// Добавляет новую позицию сотрудника в репозиторий.
    /// </summary>
    public int Post(EmployeePosition position)
    {
        var newId = employeePositions.Count > 0 ? employeePositions.Max(p => p.Id) + 1 : 1;
        position.Id = newId;
        employeePositions.Add(position);
        return newId;
    }

    /// <summary>
    /// Обновляет существующую позицию сотрудника.
    /// </summary>
    public bool Put(EmployeePosition position)
    {
        var oldValue = GetById(position.Id);
        if (oldValue == null)
            return false;

        oldValue.EmployeeId = position.EmployeeId;
        oldValue.Employee = position.Employee;
        oldValue.PositionId = position.PositionId;
        oldValue.Position = position.Position;
        oldValue.EmploymentDate = position.EmploymentDate;
        oldValue.RetirementDate = position.RetirementDate;

        return true;
    }

    /// <summary>
    /// Удаляет позицию сотрудника по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        var position = GetById(id);
        if (position == null)
            return false;

        employeePositions.Remove(position);
        return true;
    }
}