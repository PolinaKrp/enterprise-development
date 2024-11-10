using HRDepartment.Domain;

namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для получения информации об отделе
/// </summary>
public class DepartmentGetDto
{
    /// <summary>
    /// Уникальный идентификатор отдела
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название отдела
    /// </summary>
    public required string Name { get; set; }
}