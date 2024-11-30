using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDepartment.Domain.Model
{
    /// <summary>
    /// Промежуточный класс, представляющий связь между сотрудником и должностью
    /// </summary>
    [Table("EmployeePositions")]
    public class EmployeePosition
    {
        /// <summary>
        /// Уникальный идентификатор записи о позиции сотрудника
        /// </summary>
        [Key]
        [Column("EmployeePositionID")]
        public required int Id { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, связанного с должностью
        /// </summary>
        [ForeignKey("Employee")]
        [Column("EmployeeID")]
        public required int EmployeeId { get; set; }

        /// <summary>
        /// Объект сотрудника, связанного с этой должностью
        /// </summary>
        public required Employee Employee { get; set; }

        /// <summary>
        /// Идентификатор должности, на которой работает сотрудник
        /// </summary>
        [ForeignKey("Position")]
        [Column("PositionID")]
        public required int PositionId { get; set; }

        /// <summary>
        /// Объект должности, которую занимает сотрудник
        /// </summary>
        public required Position Position { get; set; }

        /// <summary>
        /// Дата принятия сотрудника на данную должность
        /// </summary>
        [Column("EmploymentDate")]
        public required DateTime EmploymentDate { get; set; }

        /// <summary>
        /// Дата увольнения сотрудника с должности
        /// </summary>
        [Column("RetirementDate")]
        public DateTime? RetirementDate { get; set; }
    }
}