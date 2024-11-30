using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDepartment.Domain.Model
{
    /// <summary>
    /// Класс, представляющий должность на предприятии
    /// </summary>
    [Table("Positions")]
    public class Position
    {
        /// <summary>
        /// Уникальный идентификатор должности
        /// </summary>
        [Key]
        [Column("PositionID")]
        public required int Id { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        [Column("Name")]
        [Required]
        [MaxLength(100)] // Максимальная длина названия должности
        public required string Name { get; set; }

        /// <summary>
        /// Идентификатор отдела, к которому относится должность
        /// </summary>
        [ForeignKey("Department")]
        [Column("DepartmentID")]
        public required int DepartmentId { get; set; }

        /// <summary>
        /// Объект отдела, к которому относится должность (связь с Department)
        /// </summary>
        public required Department Department { get; set; }

        /// <summary>
        /// Коллекция сотрудников, занимающих эту должность 
        /// </summary>
        public List<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>();
    }
}