using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

namespace HRDepartment.Api.Service;

/// <summary>
/// Сервис для управления должностями сотрудников.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с должностями сотрудников.
/// Позволяет получать информацию о всех должностях, а также добавлять, обновлять и удалять должности по их идентификаторам.
/// </summary>
public class EmployeePositionService : IService<EmployeePositionGetDto, EmployeePositionPostDto>
{
    private readonly IRepository<EmployeePosition> _employeePositionRepository; 
    private readonly IMapper _mapper; 

    /// <summary>
    /// Инициализирует новый экземпляр сервиса должностей сотрудников.
    /// </summary>
    public EmployeePositionService(IRepository<EmployeePosition> employeePositionRepository, IMapper mapper)
    {
        _employeePositionRepository = employeePositionRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает все должности сотрудников и преобразует их в DTO.
    /// </summary>
    public IEnumerable<EmployeePositionGetDto> GetAll()
    {
        var employeePositions = _employeePositionRepository.GetAll();
        return _mapper.Map<IEnumerable<EmployeePositionGetDto>>(employeePositions);
    }

    /// <summary>
    /// Получает должность сотрудника по идентификатору и преобразует ее в DTO
    /// </summary>
    public EmployeePositionGetDto? GetById(int id)
    {
        var employeePosition = _employeePositionRepository.GetById(id);
        return _mapper.Map<EmployeePositionGetDto>(employeePosition);
    }

    /// <summary>
    /// Преобразует DTO в сущность и добавляет новую должность
    /// </summary>
    public int Post(EmployeePositionPostDto postDto)
    {
        var employeePosition = _mapper.Map<EmployeePosition>(postDto);
        return _employeePositionRepository.Post(employeePosition);
    }

    /// <summary>
    /// Получает существующую должность по идентификатору
    /// </summary>
    public EmployeePositionGetDto? Put(int id, EmployeePositionPostDto putDto)
    {
        var employeePosition = _employeePositionRepository.GetById(id);
        if (employeePosition == null)
        {
            return null; 
        }

        _mapper.Map(putDto, employeePosition);
        _employeePositionRepository.Put(employeePosition);
        return _mapper.Map<EmployeePositionGetDto>(employeePosition);
    }

    /// <summary>
    /// Удаляет должность по идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        return _employeePositionRepository.Delete(id);
    }
}