namespace HRDepartment.Api.Dto;

/// <summary>
/// ArchiveOfDismissalsDto представляет архив уволенных сотрудников
/// </summary>
public class ArchiveOfDismissalsDto
{
    /// <summary>
    /// Регистрационный номер сотрудника
    /// </summary>
    public required string RegNumber { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public required string Patronymic { get; set; }

    /// <summary>
    /// Дата рождения сотрудника
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Идентификатор мастерской
    /// </summary>
    public required string WorkshopName { get; set; }

    /// <summary>
    /// Название отдела сотрудника
    /// </summary>
    public required string DepartmentName { get; set; }

    /// <summary>
    /// Название должности сотрудника
    /// </summary>
    public required string PositionName { get; set; }
}