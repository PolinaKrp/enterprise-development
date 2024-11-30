using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRDepartment.Domain.Model
{
    /// <summary>
    /// Класс, представляющий цех на предприятии
    /// </summary>
    [Table("Workshops")]
    public class Workshop
    {
        /// <summary>
        /// Уникальный идентификатор цеха
        /// </summary>
        [Key]
        [Column("WorkshopID")]
        public required int Id { get; set; }

        /// <summary>
        /// Название цеха.
        /// </summary>
        [Column("Name")]
        [Required]
        [MaxLength(100)] // Максимальная длина названия цеха
        public required string Name { get; set; }

        /// <summary>
        /// Коллекция сотрудников, работающих в данном цехе (один-ко-многим с Employee)
        /// </summary>
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}