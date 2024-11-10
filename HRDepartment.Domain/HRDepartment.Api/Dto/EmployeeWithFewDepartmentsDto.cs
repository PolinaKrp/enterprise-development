namespace HRDepartment.Api.Dto;

/// <summary>
/// Класс представляет сотрудника, который работает в 2 или более отделах организации
/// </summary>
public class EmployeeWithFewDepartmentsDto
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
    /// Количество отделов, в которых работает сотрудник
    /// </summary>
    public int CountDepart { get; set; }
}