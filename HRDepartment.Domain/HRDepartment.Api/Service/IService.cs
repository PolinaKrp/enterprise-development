namespace HRDepartment.Api.Service;

/// <summary>
/// Интерфейс для сервисов сущностей.
/// Определяет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с сущностями.
/// </summary>
public interface IService<T, TDto>
{
    /// <summary>
    /// Получает все объекты из репозитория.
    /// </summary>
    IEnumerable<T> GetAll();

    /// <summary>
    /// Получает объект по указанному идентификатору.
    /// </summary>
    T? GetById(int id);

    /// <summary>
    /// Создает новый объект на основе предоставленного DTO.
    /// </summary>
    int Post(TDto postDto);

    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO.
    /// </summary>
    T? Put(int id, TDto putDto);

    /// <summary>
    /// Удаляет объект по указанному идентификатору.
    /// </summary>
    bool Delete(int id);
}