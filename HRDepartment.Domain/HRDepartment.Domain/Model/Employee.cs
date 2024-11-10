namespace HRDepartment.Domain.Model;

/// <summary>
/// Класс, представляющий сотрудника
/// </summary>
public class Employee
{
    /// <summary>
    /// Уникальный идентификатор сотрудника
    /// </summary>
    public required int Id { get; set; }

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
    /// Цех, к которому относится сотрудник (связь с Workshop)
    /// </summary>
    public required Workshop Workshop { get; set; }

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
    /// Коллекция должностей, которые занимает сотрудник (многие-ко-многим с Position)
    /// </summary>
    public List<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();

    /// <summary>
    /// Коллекция льгот, которые получил сотрудник (многие-ко-многим с BenefitType)
    /// </summary>
    public List<EmployeeBenefit> EmployeeBenefits { get; set; } = new List<EmployeeBenefit>();
    public int DepartmentId { get; set; }
    public Department? Department { get; set; } // Связь с объектом Department

    public int GetAge()
    {
        var age = DateTime.Today.Year - BirthDate.Year;
        return BirthDate.Date > DateTime.Today.AddYears(-age) ? age-- : age;
    }
}