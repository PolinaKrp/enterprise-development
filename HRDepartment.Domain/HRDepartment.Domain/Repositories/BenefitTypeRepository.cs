using System.Collections.Generic;
using System.Linq;
using HRDepartment.Domain.Model;

namespace HRDepartment.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с данными типов льгот.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с типами льгот.
/// </summary>
public class BenefitTypeRepository(HRDepartmentContext context) : IRepository<BenefitType> 
{ 

    /// <inheritdoc />
    public IEnumerable<BenefitType> GetAll() => context.BenefitTypes.ToList();

    /// <inheritdoc />
    public BenefitType? GetById(int id) => context.BenefitTypes.FirstOrDefault(bt => bt.Id == id);

    /// <inheritdoc />
    public int Post(BenefitType benefitType)
    {
        if (context.BenefitTypes.Any(bt => bt.Name == benefitType.Name))
            return -1; 

        context.BenefitTypes.Add(benefitType);
        context.SaveChanges();
        return benefitType.Id;
    }

    /// <inheritdoc />
    public bool Put(BenefitType benefitType)
    {
        var oldValue = GetById(benefitType.Id);
        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(benefitType);
        context.SaveChanges();
        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var benefitType = GetById(id);
        if (benefitType == null)
            return false;

        context.BenefitTypes.Remove(benefitType);
        context.SaveChanges();
        return true;
    }
}