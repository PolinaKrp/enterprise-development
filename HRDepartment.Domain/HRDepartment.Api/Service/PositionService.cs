using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

namespace HRDepartment.Api.Service;

/// <summary>
/// Сервис для работы с должностями.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с должностями.
/// </summary>
public class PositionService : IService<PositionGetDto, PositionPostDto>
{
    private readonly IRepository<Position> _positionRepository; 
    private readonly IMapper _mapper; 

    /// <summary>
    /// Инициализирует новый экземпляр сервиса должностей.
    /// </summary>
    public PositionService(IRepository<Position> positionRepository, IMapper mapper)
    {
        _positionRepository = positionRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает все должности из репозитория и преобразует их в DTO.
    /// </summary>
    public IEnumerable<PositionGetDto> GetAll()
    {
        var positions = _positionRepository.GetAll();
        return _mapper.Map<IEnumerable<PositionGetDto>>(positions);
    }

    /// <summary>
    /// Получает должность по указанному идентификатору и преобразует ее в DTO.
    /// </summary>
    public PositionGetDto? GetById(int id)
    {
        var position = _positionRepository.GetById(id);
        return _mapper.Map<PositionGetDto>(position);
    }

    /// <summary>
    /// Добавляет новую должность, преобразуя данные из DTO в сущность.
    /// </summary>
    public int Post(PositionPostDto postDto)
    {
        var position = _mapper.Map<Position>(postDto);
        return _positionRepository.Post(position);
    }

    /// <summary>
    /// Обновляет существующую должность по указанному идентификатору, используя данные из DTO.
    /// </summary>
    public PositionGetDto? Put(int id, PositionPostDto putDto)
    {
        var position = _positionRepository.GetById(id);
        if (position == null)
        {
            return null; 
        }

        _mapper.Map(putDto, position);
        _positionRepository.Put(position);
        return _mapper.Map<PositionGetDto>(position);
    }

    /// <summary>
    /// Удаляет должность по указанному идентификатору.
    /// </summary>
    public bool Delete(int id)
    {
        return _positionRepository.Delete(id);
    }
}