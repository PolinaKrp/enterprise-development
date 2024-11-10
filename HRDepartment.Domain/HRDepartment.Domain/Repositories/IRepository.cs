using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Интерфейс основных методов доступа к данным
/// </summary>
public interface IRepository<T>
{
    /// <summary>
    /// Получить все объекты
    /// </summary>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    public T? GetById(int id);

    /// <summary>
    /// Создать новый объект
    /// </summary>
    public int Post(T entity);

    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    public bool Put(T entity);

    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    public bool Delete(int id);
}