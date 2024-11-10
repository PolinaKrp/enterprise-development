namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для типа льготы
/// </summary>
public class BenefitTypeGetDto
{
    /// <summary>
    /// Уникальный идентификатор типа льготы
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название типа льготы
    /// </summary>
    public required string Name { get; set; }
}