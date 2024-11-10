using System;
using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными типов льгот.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с типами льгот.
/// </summary>
public class BenefitTypeRepository : IRepository<BenefitType>
{
    private readonly List<BenefitType> benefitTypes; 

    /// <summary>
    /// Инициализирует новый экземпляр репозитория типов льгот.
    /// </summary>
    public BenefitTypeRepository(List<BenefitType> benefitTypeList)
    {
        benefitTypes = benefitTypeList;
    }

    /// <summary>
    /// Получает все типы льгот.
    /// </summary>
    public IEnumerable<BenefitType> GetAll() => benefitTypes;

    /// <summary>
    /// Получает тип льготы по указанному идентификатору.
    /// </summary>
    public BenefitType? GetById(int id) => benefitTypes.FirstOrDefault(bt => bt.Id == id);

    /// <summary>
    /// Добавляет новый тип льготы в репозиторий.
    /// </summary>
    public int Post(BenefitType benefitType)
    {
        var newId = benefitTypes.Count > 0 ? benefitTypes.Max(bt => bt.Id) + 1 : 1;
        benefitType.Id = newId; 
        benefitTypes.Add(benefitType); 
        return newId;
    }

    /// <summary>
    /// Обновляет существующий тип льготы.
    /// </summary>
    public bool Put(BenefitType benefitType)
    {
        var oldValue = GetById(benefitType.Id); 
        if (oldValue == null)
            return false; 

        oldValue.Name = benefitType.Name;
        oldValue.EmployeeBenefits = benefitType.EmployeeBenefits;

        return true; 
    }

    /// <summary>
    /// Удаляет тип льготы по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        var benefitType = GetById(id); 
        if (benefitType == null)
            return false; 

        benefitTypes.Remove(benefitType); 
        return true; 
    }
}