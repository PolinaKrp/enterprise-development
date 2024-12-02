using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными о позициях сотрудников.
    /// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с позициями сотрудников.
    /// </summary>
    public class EmployeePositionRepository : IRepository<EmployeePosition>
    {
        private readonly HRDepartmentContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с заданным контекстом базы данных.
        /// </summary>
        public EmployeePositionRepository(HRDepartmentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает все позиции сотрудников.
        /// </summary>
        public IEnumerable<EmployeePosition> GetAll() => _context.EmployeePositions.ToList();

        /// <summary>
        /// Получает позицию сотрудника по указанному идентификатору.
        /// </summary>
        public EmployeePosition? GetById(int id) => _context.EmployeePositions.Find(id);

        /// <summary>
        /// Добавляет новую позицию сотрудника в репозиторий.
        /// </summary>
        public int Post(EmployeePosition position)
        {
            _context.EmployeePositions.Add(position);
            _context.SaveChanges();
            return position.Id; 
        }

        /// <summary>
        /// Обновляет существующую позицию сотрудника.
        /// </summary>
        public bool Put(EmployeePosition position)
        {
            var oldValue = GetById(position.Id);
            if (oldValue == null)
                return false;

            // Обновляем поля
            oldValue.EmployeeId = position.EmployeeId;
            oldValue.PositionId = position.PositionId;
            oldValue.EmploymentDate = position.EmploymentDate;
            oldValue.RetirementDate = position.RetirementDate;

            _context.EmployeePositions.Update(oldValue);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет позицию сотрудника по указанному идентификатору.
        /// </summary>
        public bool Delete(int id)
        {
            var position = GetById(id);
            if (position == null)
                return false;

            _context.EmployeePositions.Remove(position);
            _context.SaveChanges();
            return true;
        }
    }
}