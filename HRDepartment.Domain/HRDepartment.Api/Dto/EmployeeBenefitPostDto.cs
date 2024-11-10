namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для создания новой записи о льготе сотрудника
/// </summary>
public class EmployeeBenefitPostDto
{
    /// <summary>
    /// Идентификатор сотрудника, который получает льготу
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Идентификатор типа льготы
    /// </summary>
    public required int BenefitTypeId { get; set; }

    /// <summary>
    /// Дата выдачи льготы
    /// </summary>
    public required DateTime IssueDate { get; set; }
}