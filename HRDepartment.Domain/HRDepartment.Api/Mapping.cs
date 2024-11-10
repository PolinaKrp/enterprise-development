using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;

namespace HRDepartment.Api;

/// <summary>
/// Класс для настройки маппинга между сущностями и DTO с использованием AutoMapper.
/// </summary>
public class Mapping : Profile
{
    /// <summary>
    /// Инициализирует новый экземпляр класса Mapping и настраивает преобразования.
    /// </summary>
    public Mapping()
    {
        // Настройка маппинга для BenefitType
        CreateMap<BenefitType, BenefitTypeGetDto>();
        CreateMap<BenefitTypePostDto, BenefitType>(); 

        // Настройка маппинга для Department
        CreateMap<Department, DepartmentGetDto>(); 
        CreateMap<DepartmentPostDto, Department>(); 

        // Настройка маппинга для EmployeeBenefit
        CreateMap<EmployeeBenefit, EmployeeBenefitGetDto>(); 
        CreateMap<EmployeeBenefitPostDto, EmployeeBenefit>(); 

        // Настройка маппинга для Employee
        CreateMap<Employee, EmployeeGetDto>();
        CreateMap<EmployeePostDto, Employee>(); 

        // Настройка маппинга для EmployeePosition
        CreateMap<EmployeePosition, EmployeePositionGetDto>(); 
        CreateMap<EmployeePositionPostDto, EmployeePosition>();

        // Настройка маппинга для Position
        CreateMap<PositionPostDto, Position>(); 
        CreateMap<Position, PositionGetDto>(); 

        // Настройка маппинга для Workshop
        CreateMap<Workshop, WorkshopGetDto>(); 
        CreateMap<WorkshopPostDto, Workshop>(); 
    }
}