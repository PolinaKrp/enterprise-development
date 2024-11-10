namespace HRDepartment.Api.Dto;

/// <summary>
/// Класс, который представляет информацию о сотруднике и его трудовом стаже
/// </summary>
public class EmployeeWorkExperienceDto
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
    /// рудовой стаж сотрудника в годах
    /// </summary>
    public required double WorkExperience { get; set; }
}