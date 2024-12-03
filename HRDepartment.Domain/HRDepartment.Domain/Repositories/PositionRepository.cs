using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о должностях.
/// </summary>
public class PositionRepository(HRDepartmentContext context) : IRepository<Position>
{

    /// <inheritdoc />
    public IEnumerable<Position> GetAll() => context.Positions;

    /// <inheritdoc />
    public Position? GetById(int id) => context.Positions.FirstOrDefault(p => p.Id == id);

    /// <inheritdoc />
    public int Post(Position position)
    {
        if (position == null)
            throw new ArgumentNullException(nameof(position));

        context.Positions.Add(position);
        context.SaveChanges();
        return position.Id; 
    }

    /// <inheritdoc />
    public bool Put(Position position)
    {
        if (position == null)
            throw new ArgumentNullException(nameof(position));

        var oldValue = GetById(position.Id);
        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(position);
        context.SaveChanges();

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var position = GetById(id);
        if (position == null)
            return false;

        context.Positions.Remove(position);
        context.SaveChanges();
        return true;
    }
}