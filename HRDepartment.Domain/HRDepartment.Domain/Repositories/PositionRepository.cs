using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о должностях.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с должностями.
/// </summary>
public class PositionRepository : IRepository<Position>
{
    private readonly List<Position> positions; 

    /// <summary>
    /// Инициализирует новый экземпляр репозитория с заданным списком должностей.
    /// </summary>
    public PositionRepository(List<Position> positionList)
    {
        positions = positionList ?? throw new ArgumentNullException(nameof(positionList));
    }

    /// <summary>
    /// Получает все должности.
    /// </summary>
    public IEnumerable<Position> GetAll() => positions;

    /// <summary>
    /// Получает должность по указанному идентификатору.
    /// </summary>
    public Position? GetById(int id) => positions.FirstOrDefault(p => p.Id == id);

    /// <summary>
    /// Добавляет новую должность в репозиторий.
    /// </summary>
    public int Post(Position position)
    {
        if (position == null)
            throw new ArgumentNullException(nameof(position));

        var newId = positions.Count > 0 ? positions.Max(p => p.Id) + 1 : 1;
        position.Id = newId;
        positions.Add(position);
        return newId;
    }

    /// <summary>
    /// Обновляет существующую должность.
    /// </summary>
    public bool Put(Position position)
    {
        if (position == null)
            throw new ArgumentNullException(nameof(position));

        var oldValue = GetById(position.Id);
        if (oldValue == null)
            return false;

        oldValue.Name = position.Name;
        oldValue.DepartmentId = position.DepartmentId;
        oldValue.Department = position.Department;

        return true;
    }

    /// <summary>
    /// Удаляет должность по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        var position = GetById(id);
        if (position == null)
            return false;

        positions.Remove(position);
        return true;
    }
}