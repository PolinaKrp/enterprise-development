namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для создания новой должности
/// </summary>
public class PositionPostDto
{
    /// <summary>
    /// Название должности
    /// </summary>
    public required string Name { get; set; } 

    /// <summary>
    /// Идентификатор отдела, к которому относится должность
    /// </summary>
    public required int DepartmentId { get; set; }
}