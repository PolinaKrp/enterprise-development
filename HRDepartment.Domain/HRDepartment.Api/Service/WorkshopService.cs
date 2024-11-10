using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

namespace HRDepartment.Api.Service;

/// <summary>
/// Сервис для работы с мастерскими.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с мастерскими.
/// </summary>
public class WorkshopService : IService<WorkshopGetDto, WorkshopPostDto>
{
    private readonly IRepository<Workshop> _workshopRepository;
    private readonly IMapper _mapper; 

    /// <summary>
    /// Инициализирует новый экземпляр сервиса мастерских.
    /// </summary>
    public WorkshopService(IRepository<Workshop> workshopRepository, IMapper mapper)
    {
        _workshopRepository = workshopRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает все мастерские из репозитория и преобразует их в DTO.
    /// </summary>
    public IEnumerable<WorkshopGetDto> GetAll()
    {
        var workshops = _workshopRepository.GetAll();
        return _mapper.Map<IEnumerable<WorkshopGetDto>>(workshops);
    }

    /// <summary>
    /// Получает мастерскую по указанному идентификатору и преобразует ее в DTO.
    /// </summary>
    public WorkshopGetDto? GetById(int id)
    {
        var workshop = _workshopRepository.GetById(id);
        return _mapper.Map<WorkshopGetDto>(workshop);
    }

    /// <summary>
    /// Добавляет новую мастерскую, преобразуя данные из DTO в сущность.
    /// </summary>
    public int Post(WorkshopPostDto postDto)
    {
        var workshop = _mapper.Map<Workshop>(postDto);
        return _workshopRepository.Post(workshop);
    }

    /// <summary>
    /// Обновляет существующую мастерскую по указанному идентификатору, используя данные из DTO.
    /// </summary>
    public WorkshopGetDto? Put(int id, WorkshopPostDto putDto)
    {
        var workshop = _workshopRepository.GetById(id);
        if (workshop == null)
        {
            return null; 
        }

        _mapper.Map(putDto, workshop);
        _workshopRepository.Put(workshop);
        return _mapper.Map<WorkshopGetDto>(workshop);
    }

    /// <summary>
    /// Удаляет мастерскую по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        return _workshopRepository.Delete(id);
    }
}