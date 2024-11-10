namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для получения информации о цехах
/// </summary>
public class WorkshopGetDto
{
    /// <summary>
    /// Уникальный идентификатор цеха
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название цеха
    /// </summary>
    public required string Name { get; set; }
}