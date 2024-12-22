using HRDepartment.Domain;
using System.ComponentModel.DataAnnotations;

namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для создания нового типа льготы
/// </summary>
public class BenefitTypePostDto
{
    //public required int Id { get; set; }
    /// <summary>
    /// Название типа льготы
    /// </summary>
    public required string Name { get; set; }
}