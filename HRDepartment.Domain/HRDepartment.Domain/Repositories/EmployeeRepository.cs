using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными сотрудников.
    /// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с данными сотрудников.
    /// </summary>
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly HRDepartmentContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с заданным контекстом базы данных.
        /// </summary>
        public EmployeeRepository(HRDepartmentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает всех сотрудников.
        /// </summary>
        public IEnumerable<Employee> GetAll() => _context.Employees.ToList();

        /// <summary>
        /// Получает сотрудника по указанному идентификатору.
        /// </summary>
        public Employee? GetById(int id) => _context.Employees.Find(id);

        /// <summary>
        /// Добавляет нового сотрудника в репозиторий.
        /// </summary>
        public int Post(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id; // Предполагается, что Id будет автоматически сгенерирован базой данных
        }

        /// <summary>
        /// Обновляет существующего сотрудника.
        /// </summary>
        public bool Put(Employee employee)
        {
            var oldValue = GetById(employee.Id);
            if (oldValue == null)
                return false;

            // Обновляем поля
            oldValue.RegNumber = employee.RegNumber;
            oldValue.FirstName = employee.FirstName;
            oldValue.LastName = employee.LastName;
            oldValue.Patronymic = employee.Patronymic;
            oldValue.BirthDate = employee.BirthDate;
            oldValue.WorkshopId = employee.WorkshopId;
            oldValue.WorkPhoneNumber = employee.WorkPhoneNumber;
            oldValue.PersonalPhoneNumber = employee.PersonalPhoneNumber;
            oldValue.Address = employee.Address;
            oldValue.FamilyMembersCount = employee.FamilyMembersCount;
            oldValue.ChildrenCount = employee.ChildrenCount;
            oldValue.MaritalStatus = employee.MaritalStatus;
            oldValue.EmployeePositions = employee.EmployeePositions;
            oldValue.EmployeeBenefits = employee.EmployeeBenefits;

            _context.Employees.Update(oldValue);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет сотрудника по указанному идентификатору.
        /// </summary>
        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }
    }
}