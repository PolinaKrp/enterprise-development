namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для создания нового цеха
/// </summary>
public class WorkshopPostDto
{
    /// <summary>
    /// Название цеха
    /// </summary>
    public required string Name { get; set; } 
}