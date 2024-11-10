namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для создания новой записи о позиции сотрудника
/// </summary>
public class EmployeePositionPostDto
{
    /// <summary>
    /// Идентификатор сотрудника, связанного с должностью
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Идентификатор должности, на которой работает сотрудник
    /// </summary>
    public required int PositionId { get; set; }

    /// <summary>
    /// Дата принятия сотрудника на данную должность
    /// </summary>
    public required DateTime EmploymentDate { get; set; }

    /// <summary>
    /// Дата увольнения сотрудника с должности (может быть null)
    /// </summary>
    public DateTime? RetirementDate { get; set; }
}