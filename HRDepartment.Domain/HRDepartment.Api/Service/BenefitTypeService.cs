using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;

namespace HRDepartment.Api.Service;

/// <summary>
/// Сервис для работы с типами льгот.
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с типами льгот.
/// </summary>
public class BenefitTypeService : IService<BenefitTypeGetDto, BenefitTypePostDto>
{
    private readonly IRepository<BenefitType> _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Инициализирует новый экземпляр сервиса типов льгот.
    /// </summary>
    public BenefitTypeService(IRepository<BenefitType> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает все типы льгот из репозитория и преобразует их в DTO.
    /// </summary>
    /// <returns>Список DTO всех типов льгот.</returns>
    public IEnumerable<BenefitTypeGetDto> GetAll()
    {
        return _mapper.Map<IEnumerable<BenefitTypeGetDto>>(_repository.GetAll());
    }

    /// <summary>
    /// Получает тип льготы по указанному идентификатору и преобразует его в DTO.
    /// </summary>
    /// <returns>DTO типа льготы, если он найден; в противном случае - null.</returns>
    public BenefitTypeGetDto? GetById(int id)
    {
        var benefitType = _repository.GetById(id);
        return _mapper.Map<BenefitTypeGetDto>(benefitType);
    }

    /// <summary>
    /// Добавляет новый тип льготы, преобразуя данные из DTO в сущность.
    /// </summary>
    /// <returns>Идентификатор добавленного типа льготы.</returns>
    public int Post(BenefitTypePostDto postDto)
    {
        var benefitType = _mapper.Map<BenefitType>(postDto);
        return _repository.Post(benefitType);
    }

    /// <summary>
    /// Обновляет существующий тип льготы по указанному идентификатору, используя данные из DTO.
    /// </summary>
    /// <returns>DTO обновленного типа льготы, если он найден; в противном случае - null.</returns>
    public BenefitTypeGetDto? Put(int id, BenefitTypePostDto putDto)
    {
        var benefitType = _repository.GetById(id);
        if (benefitType == null)
        {
            return null;
        }

        benefitType.Name = putDto.Name;
        var isUpdated = _repository.Put(benefitType);
        return isUpdated ? _mapper.Map<BenefitTypeGetDto>(benefitType) : null;
    }

    /// <summary>
    /// Удаляет тип льготы по указанному идентификатору.
    /// </summary>
    /// <returns>True, если удаление прошло успешно; в противном случае - false.</returns>
    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}