﻿namespace HRDepartment.Api.Dto;

/// <summary>
/// DTO для создания нового сотрудника
/// </summary>
public class EmployeePostDto
{
    /// <summary>
    /// Регистрационный номер сотрудника
    /// </summary>
    public required string RegNumber { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия сотрудника
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Отчество сотрудника
    /// </summary>
    public required string Patronymic { get; set; } 

    /// <summary>
    /// Дата рождения сотрудника
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Идентификатор цеха, к которому относится сотрудник
    /// </summary>
    public int WorkshopId { get; set; }

    /// <summary>
    /// Рабочий номер телефона сотрудника
    /// </summary>
    public required string WorkPhoneNumber { get; set; }

    /// <summary>
    /// Личный номер телефона сотрудника
    /// </summary>
    public required string PersonalPhoneNumber { get; set; } 

    /// <summary>
    /// Адрес проживания сотрудника
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Количество членов семьи у сотрудника
    /// </summary>
    public required int FamilyMembersCount { get; set; }

    /// <summary>
    /// Количество детей у сотрудника
    /// </summary>
    public required int ChildrenCount { get; set; }

    /// <summary>
    /// Семейное положение сотрудника
    /// </summary>
    public required string MaritalStatus { get; set; } 

    /// <summary>
    /// Идентификатор отдела, к которому относится сотрудник
    /// </summary>
    public required int DepartmentId { get; set; }
}