using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

namespace HRDepartment.Api.Service;

/// <summary>
/// Сервис для работы с отделами.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с отделами.
/// Позволяет получать информацию о всех отделах, а также добавлять, обновлять и удалять отделы по их идентификаторам.
/// </summary>
public class DepartmentService : IService<DepartmentGetDto, DepartmentPostDto>
{
    private readonly IRepository<Department> _departmentRepository;
    private readonly IMapper _mapper; 

    /// <summary>
    /// Инициализирует новый экземпляр сервиса отделов.
    /// </summary>
    public DepartmentService(IRepository<Department> departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает все отделы из репозитория и преобразует их в DTO.
    /// </summary>
    /// <returns>Список DTO всех отделов.</returns>
    public IEnumerable<DepartmentGetDto> GetAll()
    {
        var departments = _departmentRepository.GetAll();
        return _mapper.Map<IEnumerable<DepartmentGetDto>>(departments);
    }

    /// <summary>
    /// Получает отдел по указанному идентификатору и преобразует его в DTO.
    /// </summary>
    /// <returns>DTO отдела, если он найден; в противном случае - null.</returns>
    public DepartmentGetDto? GetById(int id)
    {
        var department = _departmentRepository.GetById(id);
        return _mapper.Map<DepartmentGetDto>(department);
    }

    /// <summary>
    /// Добавляет новый отдел, преобразуя данные из DTO в сущность.
    /// </summary>
    /// <returns>Идентификатор добавленного отдела.</returns>
    public int Post(DepartmentPostDto postDto)
    {
        var department = _mapper.Map<Department>(postDto);
        return _departmentRepository.Post(department);
    }

    /// <summary>
    /// Обновляет существующий отдел по указанному идентификатору, используя данные из DTO.
    /// </summary>
    /// <returns>DTO обновленного отдела, если он найден; в противном случае - null.</returns>
    public DepartmentGetDto? Put(int id, DepartmentPostDto putDto)
    {
        var department = _departmentRepository.GetById(id);
        if (department == null)
        {
            return null; // Возвращает null, если отдел не найден
        }

        var updatedDepartment = _mapper.Map(putDto, department);
        _departmentRepository.Put(updatedDepartment);
        return _mapper.Map<DepartmentGetDto>(updatedDepartment);
    }

    /// <summary>
    /// Удаляет отдел по указанному идентификатору.
    /// </summary>
    /// <returns>True, если удаление прошло успешно; в противном случае - false.</returns>
    public bool Delete(int id)
    {
        return _departmentRepository.Delete(id);
    }
}