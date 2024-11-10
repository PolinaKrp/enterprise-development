using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

namespace HRDepartment.Api.Service;

/// <summary>
/// Сервис для работы с сотрудниками.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с сотрудниками.
/// </summary>
public class EmployeeService : IService<EmployeeGetDto, EmployeePostDto>
{
    private readonly IRepository<Employee> _employeeRepository; 
    private readonly IMapper _mapper;

    /// <summary>
    /// Инициализирует новый экземпляр сервиса сотрудников.
    /// </summary>
    public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает всех сотрудников из репозитория и преобразует их в DTO.
    /// </summary>
    /// <returns>Список DTO всех сотрудников.</returns>
    public IEnumerable<EmployeeGetDto> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        return _mapper.Map<IEnumerable<EmployeeGetDto>>(employees);
    }

    /// <summary>
    /// Получает сотрудника по указанному идентификатору и преобразует его в DTO.
    /// </summary>
    /// <returns>DTO сотрудника, если он найден; в противном случае - null.</returns>
    public EmployeeGetDto? GetById(int id)
    {
        var employee = _employeeRepository.GetById(id);
        return _mapper.Map<EmployeeGetDto>(employee);
    }

    /// <summary>
    /// Добавляет нового сотрудника, преобразуя данные из DTO в сущность.
    /// </summary>
    /// <returns>Идентификатор добавленного сотрудника.</returns>
    public int Post(EmployeePostDto postDto)
    {
        var employee = _mapper.Map<Employee>(postDto);
        return _employeeRepository.Post(employee);
    }

    /// <summary>
    /// Обновляет существующего сотрудника по указанному идентификатору, используя данные из DTO.
    /// </summary>
    /// <returns>DTO обновленного сотрудника, если он найден; в противном случае - null.</returns>
    public EmployeeGetDto? Put(int id, EmployeePostDto putDto)
    {
        var employee = _employeeRepository.GetById(id);
        if (employee == null)
        {
            return null; 
        }

        _mapper.Map(putDto, employee);
        _employeeRepository.Put(employee);
        return _mapper.Map<EmployeeGetDto>(employee);
    }

    /// <summary>
    /// Удаляет сотрудника по указанному идентификатору.
    /// </summary>
    /// <returns>True, если удаление прошло успешно; в противном случае - false.</returns>
    public bool Delete(int id)
    {
        return _employeeRepository.Delete(id);
    }
}