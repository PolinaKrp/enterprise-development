using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о позициях сотрудников.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с позициями сотрудников.
/// </summary>
public class EmployeePositionRepository(HRDepartmentContext context) : IRepository<EmployeePosition> 
{ 

    /// <summary>
    /// Получает все позиции сотрудников.
    /// </summary>
    public IEnumerable<EmployeePosition> GetAll() => context.EmployeePositions.ToList();

    /// <summary>
    /// Получает позицию сотрудника по указанному идентификатору.
    /// </summary>
    public EmployeePosition? GetById(int id) => context.EmployeePositions.Find(id);

    /// <summary>
    /// Добавляет новую позицию сотрудника в репозиторий.
    /// </summary>
    public int Post(EmployeePosition position)
    {
        context.EmployeePositions.Add(position);
        context.SaveChanges();
        return position.Id; 
    }

    /// <summary>
    /// Обновляет существующую позицию сотрудника.
    /// </summary>
    public bool Put(EmployeePosition position)
    {
        var oldValue = GetById(position.Id);
        if (oldValue == null)
            return false;

        // Обновляем поля
        oldValue.EmployeeId = position.EmployeeId;
        oldValue.PositionId = position.PositionId;
        oldValue.EmploymentDate = position.EmploymentDate;
        oldValue.RetirementDate = position.RetirementDate;

        context.EmployeePositions.Update(oldValue);
        context.SaveChanges();
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

        context.EmployeePositions.Remove(position);
        context.SaveChanges();
        return true;
    }
}