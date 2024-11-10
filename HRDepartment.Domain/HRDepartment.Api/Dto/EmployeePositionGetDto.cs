namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для получения информации о позициях сотрудника
/// </summary>
public class EmployeePositionGetDto
{
    /// <summary>
    /// Уникальный идентификатор записи о позиции сотрудника
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор сотрудника, связанного с должностью
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Имя сотрудника, связанного с этой должностью
    /// </summary>
    public required string EmployeeName { get; set; } 

    /// <summary>
    /// Идентификатор должности, на которой работает сотрудник
    /// </summary>
    public required int PositionId { get; set; }

    /// <summary>
    /// Название должности, которую занимает сотрудник
    /// </summary>
    public required string PositionName { get; set; }

    /// <summary>
    /// Дата принятия сотрудника на данную должность
    /// </summary>
    public required DateTime EmploymentDate { get; set; }

    /// <summary>
    /// Дата увольнения сотрудника с должности
    /// </summary>
    public DateTime? RetirementDate { get; set; }
}