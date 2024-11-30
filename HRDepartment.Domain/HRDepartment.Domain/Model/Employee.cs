using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDepartment.Domain.Model
{
    /// <summary>
    /// Класс, представляющий сотрудника
    /// </summary>
    [Table("Employees")]
    public class Employee
    {
        /// <summary>
        /// Уникальный идентификатор сотрудника
        /// </summary>
        [Key]
        [Column("EmployeeID")]
        public required int Id { get; set; }

        /// <summary>
        /// Регистрационный номер сотрудника
        /// </summary>
        [Column("RegNumber")]
        [Required]
        [MaxLength(50)] // Максимальная длина регистрационного номера
        public required string RegNumber { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Column("FirstName")]
        [Required]
        [MaxLength(100)] // Максимальная длина имени
        public required string FirstName { get; set; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        [Column("LastName")]
        [Required]
        [MaxLength(100)] // Максимальная длина фамилии
        public required string LastName { get; set; }

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        [Column("Patronymic")]
        [Required]
        [MaxLength(100)] // Максимальная длина отчества
        public required string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Идентификатор цеха, к которому относится сотрудник
        /// </summary>
        [ForeignKey("Workshop")]
        [Column("WorkshopID")]
        public int WorkshopId { get; set; }

        /// <summary>
        /// Цех, к которому относится сотрудник (связь с Workshop)
        /// </summary>
        public required Workshop Workshop { get; set; }

        /// <summary>
        /// Рабочий номер телефона сотрудника
        /// </summary>
        [Column("WorkPhoneNumber")]
        [Required]
        [MaxLength(15)] // Максимальная длина рабочего номера
        public required string WorkPhoneNumber { get; set; }

        /// <summary>
        /// Личный номер телефона сотрудника
        /// </summary>
        [Column("PersonalPhoneNumber")]
        [Required]
        [MaxLength(15)] // Максимальная длина личного номера
        public required string PersonalPhoneNumber { get; set; }

        /// <summary>
        /// Адрес проживания сотрудника
        /// </summary>
        [Column("Address")]
        [Required]
        [MaxLength(250)] // Максимальная длина адреса
        public required string Address { get; set; }

        /// <summary>
        /// Количество членов семьи у сотрудника
        /// </summary>
        [Column("FamilyMembersCount")]
        [Required]
        public required int FamilyMembersCount { get; set; }

        /// <summary>
        /// Количество детей у сотрудника
        /// </summary>
        [Column("ChildrenCount")]
        [Required]
        public required int ChildrenCount { get; set; }

        /// <summary>
        /// Семейное положение сотрудника
        /// </summary>
        [Column("MaritalStatus")]
        [Required]
        [MaxLength(50)] // Максимальная длина семейного положения
        public required string MaritalStatus { get; set; }

        /// <summary>
        /// Коллекция должностей, которые занимает сотрудник (многие-ко-многим с Position)
        /// </summary>
        public List<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();

        /// <summary>
        /// Коллекция льгот, которые получил сотрудник (многие-ко-многим с BenefitType)
        /// </summary>
        public List<EmployeeBenefit> EmployeeBenefits { get; set; } = new List<EmployeeBenefit>();

        /// <summary>
        /// Метод для получения возраста сотрудника
        /// </summary>
        public int GetAge()
        {
            var age = DateTime.Today.Year - BirthDate.Year;
            return BirthDate.Date > DateTime.Today.AddYears(-age) ? age-- : age;
        }
    }
}