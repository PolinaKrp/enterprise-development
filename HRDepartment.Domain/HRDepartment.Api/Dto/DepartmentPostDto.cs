namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для создания нового отдела
/// </summary>
public class DepartmentPostDto
{
    /// <summary>
    /// Название отдела
    /// </summary>
    public required string Name { get; set; }
}