using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDepartment.Domain.Model
{
    /// <summary>
    /// Класс, представляющий тип льготы
    /// </summary>
    [Table("BenefitTypes")]
    public class BenefitType
    {
        /// <summary>
        /// Уникальный идентификатор типа льготы
        /// </summary>
        [Key]
        [Column("BenefitTypeID")]
        public required int Id { get; set; }

        /// <summary>
        /// Название типа льготы
        /// </summary>
        [Column("Name")]
        [Required]
        [MaxLength(100)] // Максимальная длина названия льготы
        public required string Name { get; set; }

        /// <summary>
        /// Коллекция льгот, которые были выданы сотрудникам (многие-ко-многим с Employee через EmployeeBenefit)
        /// </summary>
        public List<EmployeeBenefit> EmployeeBenefits { get; set; } = new List<EmployeeBenefit>();
    }
}