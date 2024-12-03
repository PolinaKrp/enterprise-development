using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о цехах.
/// </summary>
public class WorkshopRepository(HRDepartmentContext context) : IRepository<Workshop> 
{ 

    /// <inheritdoc />
    public IEnumerable<Workshop> GetAll() => context.Workshops;

    /// <inheritdoc />
    public Workshop? GetById(int id) => context.Workshops.FirstOrDefault(w => w.Id == id);

    /// <inheritdoc />
    public int Post(Workshop workshop)
    {
        if (workshop == null)
            throw new ArgumentNullException(nameof(workshop));

        context.Workshops.Add(workshop);
        context.SaveChanges();
        return workshop.Id; 
    }

    /// <inheritdoc />
    public bool Put(Workshop workshop)
    {
        if (workshop == null)
            throw new ArgumentNullException(nameof(workshop));

        var oldValue = GetById(workshop.Id);
        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(workshop);
        context.SaveChanges();

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var workshop = GetById(id);
        if (workshop == null)
            return false;

        context.Workshops.Remove(workshop);
        context.SaveChanges();
        return true;
    }
}