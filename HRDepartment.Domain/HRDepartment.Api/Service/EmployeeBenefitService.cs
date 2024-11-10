using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

namespace HRDepartment.Api.Service;

/// <summary>
/// Сервис для работы с льготами сотрудников.
/// Предоставляет методы для выполнения операций CRUD с льготами сотрудников.
/// </summary>
public class EmployeeBenefitService
{
    private readonly IRepository<EmployeeBenefit> _employeeBenefitRepository;
    private readonly IMapper _mapper; 

    /// <summary>
    /// Инициализирует новый экземпляр сервиса льгот сотрудников.
    /// </summary>
    public EmployeeBenefitService(IRepository<EmployeeBenefit> employeeBenefitRepository, IMapper mapper)
    {
        _employeeBenefitRepository = employeeBenefitRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает список всех льгот сотрудников.
    /// </summary>
    public IEnumerable<EmployeeBenefitGetDto> GetAll()
    {
        var employeeBenefits = _employeeBenefitRepository.GetAll();
        return _mapper.Map<IEnumerable<EmployeeBenefitGetDto>>(employeeBenefits);
    }

    /// <summary>
    /// Получает льготу сотрудника по указанному идентификатору.
    /// </summary>
    public EmployeeBenefitGetDto? GetById(int id)
    {
        var employeeBenefit = _employeeBenefitRepository.GetById(id);
        return _mapper.Map<EmployeeBenefitGetDto>(employeeBenefit);
    }

    /// <summary>
    /// Добавляет новую льготу сотрудника.
    /// </summary>
    public int Post(EmployeeBenefitPostDto postDto)
    {
        var employeeBenefit = _mapper.Map<EmployeeBenefit>(postDto);
        return _employeeBenefitRepository.Post(employeeBenefit);
    }

    /// <summary>
    /// Обновляет информацию о льготе сотрудника по указанному идентификатору.
    /// </summary>
    public EmployeeBenefitGetDto? Put(int id, EmployeeBenefitPostDto putDto)
    {
        var employeeBenefit = _employeeBenefitRepository.GetById(id);
        if (employeeBenefit == null)
        {
            return null; 
        }

        var updatedEmployeeBenefit = _mapper.Map(putDto, employeeBenefit);
        _employeeBenefitRepository.Put(updatedEmployeeBenefit);
        return _mapper.Map<EmployeeBenefitGetDto>(updatedEmployeeBenefit);
    }

    /// <summary>
    /// Удаляет льготу сотрудника по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        return _employeeBenefitRepository.Delete(id);
    }
}