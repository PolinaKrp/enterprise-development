using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными о цехах.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с данными о цехах.
/// </summary>
public class WorkshopRepository : IRepository<Workshop>
{
    private readonly List<Workshop> workshops; 

    /// <summary>
    /// Инициализирует новый экземпляр репозитория с заданным списком цехов.
    /// </summary>
    public WorkshopRepository(List<Workshop> workshopList)
    {
        workshops = workshopList ?? throw new ArgumentNullException(nameof(workshopList));
    }

    /// <summary>
    /// Получает все цехи.
    /// </summary>
    public IEnumerable<Workshop> GetAll() => workshops;

    /// <summary>
    /// Получает цех по указанному идентификатору.
    /// </summary>
    public Workshop? GetById(int id) => workshops.FirstOrDefault(w => w.Id == id);

    /// <summary>
    /// Добавляет новый цех в репозиторий.
    /// </summary>
    public int Post(Workshop workshop)
    {
        if (workshop == null)
            throw new ArgumentNullException(nameof(workshop));

        var newId = workshops.Count > 0 ? workshops.Max(w => w.Id) + 1 : 1;
        workshop.Id = newId;
        workshops.Add(workshop);
        return newId;
    }

    /// <summary>
    /// Обновляет существующий цех.
    /// </summary>
    public bool Put(Workshop workshop)
    {
        if (workshop == null)
            throw new ArgumentNullException(nameof(workshop));

        var oldValue = GetById(workshop.Id);
        if (oldValue == null)
            return false;

        oldValue.Name = workshop.Name;
        oldValue.Employees = workshop.Employees;

        return true;
    }

    /// <summary>
    /// Удаляет цех по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        var workshop = GetById(id);
        if (workshop == null)
            return false;

        workshops.Remove(workshop);
        return true;
    }
}