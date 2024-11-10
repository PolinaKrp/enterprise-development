namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для получения информации о льготах сотрудника
/// </summary>
public class EmployeeBenefitGetDto
{
    /// <summary>
    /// Уникальный идентификатор записи о льготе сотрудника
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор сотрудника, который получил льготу
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Имя сотрудника, который получил льготу
    /// </summary>
    public required string EmployeeName { get; set; } 

    /// <summary>
    /// Идентификатор типа льготы
    /// </summary>
    public required int BenefitTypeId { get; set; }

    /// <summary>
    /// Название типа льготы, которую получил сотрудник
    /// </summary>
    public required string BenefitTypeName { get; set; } 

    /// <summary>
    /// Дата выдачи льготы
    /// </summary>
    public required DateTime IssueDate { get; set; }
}