using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service; 
using Microsoft.AspNetCore.Mvc;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления типами льгот.
/// Предоставляет методы для получения, добавления, обновления и удаления типов льгот.
/// </summary>
[Route("[controller]")]
[ApiController]
public class BenefitTypeController : ControllerBase
{
    private readonly BenefitTypeService _service; 

    public BenefitTypeController(BenefitTypeService service)
    {
        _service = service; 
    }

    /// <summary>
    /// Получает список всех типов льгот.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<BenefitTypeGetDto>> Get()
    {
        var benefitTypes = _service.GetAll();
        return Ok(benefitTypes);
    }

    /// <summary>
    /// Получает тип льготы по уникальному идентификатору.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<BenefitTypeGetDto> Get(int id)
    {
        var benefitType = _service.GetById(id);
        if (benefitType == null)
        {
            return NotFound($"Тип льготы с идентификатором {id} не найден.");
        }
        return Ok(benefitType);
    }

    /// <summary>
    /// Добавляет новый тип льготы.
    /// </summary>
    [HttpPost]
    public ActionResult<BenefitTypeGetDto> Post([FromBody] BenefitTypePostDto postDto)
    {
        if (postDto == null)
        {
            return BadRequest("Тип льготы не может быть null.");
        }

        var newId = _service.Post(postDto);
        var createdBenefitTypeDto = _service.GetById(newId); 
        return CreatedAtAction(nameof(Get), new { id = newId }, createdBenefitTypeDto);
    }

    /// <summary>
    /// Обновляет информацию о существующем типе льготы.
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<BenefitTypeGetDto> Put(int id, [FromBody] BenefitTypePostDto putDto)
    {
        if (putDto == null)
        {
            return BadRequest("Тип льготы не может быть null.");
        }

        var updatedBenefitType = _service.Put(id, putDto);
        if (updatedBenefitType == null)
        {
            return NotFound($"Тип льготы с идентификатором {id} не найден.");
        }

        return Ok(updatedBenefitType);
    }

    /// <summary>
    /// Удаляет тип льготы по уникальному идентификатору.
    /// </summary>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var isDeleted = _service.Delete(id);
        if (!isDeleted)
        {
            return NotFound($"Тип льготы с идентификатором {id} не найден.");
        }

        return Ok($"Тип льготы с идентификатором {id} удалён.");
    }
}