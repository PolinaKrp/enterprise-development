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
        CreateMap<BenefitType, BenefitTypeGetDto>().ReverseMap();
        CreateMap<BenefitTypePostDto, BenefitType>();

        // Настройка маппинга для Department
        CreateMap<Department, DepartmentGetDto>().ReverseMap();
        CreateMap<DepartmentPostDto, Department>();

        // Настройка маппинга для EmployeeBenefit
        CreateMap<EmployeeBenefit, EmployeeBenefitGetDto>().ReverseMap();
        CreateMap<EmployeeBenefitPostDto, EmployeeBenefit>();

        // Настройка маппинга для Employee
        CreateMap<Employee, EmployeeGetDto>().ReverseMap();
        CreateMap<EmployeePostDto, Employee>();

        // Настройка маппинга для EmployeePosition
        CreateMap<EmployeePosition, EmployeePositionGetDto>().ReverseMap();
        CreateMap<EmployeePositionPostDto, EmployeePosition>();

        // Настройка маппинга для Position
        CreateMap<Position, PositionGetDto>().ReverseMap();
        CreateMap<PositionPostDto, Position>();

        // Настройка маппинга для Workshop
        CreateMap<Workshop, WorkshopGetDto>().ReverseMap();
        CreateMap<WorkshopPostDto, Workshop>();
    }
}