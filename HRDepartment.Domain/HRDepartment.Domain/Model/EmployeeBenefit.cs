using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDepartment.Domain.Model
{
    /// <summary>
    /// Промежуточный класс, представляющий льготы, которые получает сотрудник
    /// </summary>
    [Table("EmployeeBenefits")]
    public class EmployeeBenefit
    {
        /// <summary>
        /// Уникальный идентификатор записи о льготе сотрудника
        /// </summary>
        [Key]
        [Column("EmployeeBenefitID")]
        public required int Id { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, который получил льготу
        /// </summary>
        [ForeignKey("Employee")]
        [Column("EmployeeID")]
        public required int EmployeeId { get; set; }

        /// <summary>
        /// Объект сотрудника, который получил льготу
        /// </summary>
        public required Employee Employee { get; set; }

        /// <summary>
        /// Идентификатор типа льготы
        /// </summary>
        [ForeignKey("BenefitType")]
        [Column("BenefitTypeID")]
        public required int BenefitTypeId { get; set; }

        /// <summary>
        /// Объект типа льготы, которую получил сотрудник
        /// </summary>
        public required BenefitType BenefitType { get; set; }

        /// <summary>
        /// Дата выдачи льготы
        /// </summary>
        [Column("IssueDate")]
        public required DateTime IssueDate { get; set; }
    }
}