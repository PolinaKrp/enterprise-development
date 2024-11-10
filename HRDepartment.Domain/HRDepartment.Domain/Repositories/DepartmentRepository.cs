using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

using System.Xml.Linq;

/// <summary>
/// Репозиторий для управления данными отделов.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с отделами.
/// </summary>
public class DepartmentRepository : IRepository<Department>
{
    private readonly List<Department> departments; 

    /// <summary>
    /// Инициализирует новый экземпляр репозитория с пустым списком отделов.
    /// </summary>
    public DepartmentRepository()
    {
        departments = new List<Department>();
    }

    /// <summary>
    /// Инициализирует новый экземпляр репозитория с заданным списком отделов.
    /// </summary>
    public DepartmentRepository(List<Department> departmentList)
    {
        departments = departmentList;
    }

    /// <summary>
    /// Получает все отделы.
    /// </summary>
    public IEnumerable<Department> GetAll() => departments;

    /// <summary>
    /// Получает отдел по указанному идентификатору.
    /// </summary>
    public Department? GetById(int id) => departments.FirstOrDefault(d => d.Id == id);

    /// <summary>
    /// Добавляет новый отдел в репозиторий.
    /// </summary>
    public int Post(Department department)
    {
        var newId = departments.Count > 0 ? departments.Max(d => d.Id) + 1 : 1;
        department.Id = newId;
        departments.Add(department);
        return newId;
    }

    /// <summary>
    /// Обновляет существующий отдел.
    /// </summary>
    public bool Put(Department department)
    {
        var oldValue = GetById(department.Id);
        if (oldValue == null)
            return false;

        oldValue.Name = department.Name;
        oldValue.Positions = department.Positions;

        return true;
    }

    /// <summary>
    /// Удаляет отдел по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        var department = GetById(id);
        if (department == null)
            return false;

        departments.Remove(department);
        return true;
    }
}