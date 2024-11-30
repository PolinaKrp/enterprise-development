using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDepartment.Domain.Model
{
    /// <summary>
    /// Класс, представляющий отдел на предприятии
    /// </summary>
    [Table("Departments")]
    public class Department
    {
        /// <summary>
        /// Уникальный идентификатор отдела
        /// </summary>
        [Key]
        [Column("DepartmentID")]
        public required int Id { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        [Column("Name")]
        [Required]
        [MaxLength(100)] // Максимальная длина названия отдела
        public required string Name { get; set; }

        /// <summary>
        /// Коллекция должностей, принадлежащих данному отделу
        /// </summary>
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}