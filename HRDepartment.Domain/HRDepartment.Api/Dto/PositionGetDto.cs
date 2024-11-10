namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для получения информации о должностях
/// </summary>
public class PositionGetDto
{
    /// <summary>
    /// Уникальный идентификатор должности
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название должности
    /// </summary>
    public required string Name { get; set; } 

    /// <summary>
    /// Идентификатор отдела, к которому относится должность
    /// </summary>
    public required int DepartmentId { get; set; }

    /// <summary>
    /// Название отдела, к которому относится должность
    /// </summary>
    public required string DepartmentName { get; set; }
}