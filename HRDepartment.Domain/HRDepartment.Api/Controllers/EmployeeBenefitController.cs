using Microsoft.AspNetCore.Mvc;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service; 
using System.Collections.Generic;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления льготами сотрудников.
/// Предоставляет методы для получения, добавления, обновления и удаления льгот.
/// </summary>
[Route("[controller]")]
[ApiController]
public class EmployeeBenefitController : ControllerBase
{
    private readonly EmployeeBenefitService _employeeBenefitService; 

    /// <summary>
    /// Инициализирует новый экземпляр контроллера льгот сотрудников.
    /// </summary>
    public EmployeeBenefitController(EmployeeBenefitService employeeBenefitService)
    {
        _employeeBenefitService = employeeBenefitService; 
    }

    /// <summary>
    /// Получает список всех льгот сотрудников.
    /// </summary>
    /// <returns>Список льгот сотрудников.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeBenefitGetDto>> Get()
    {
        var employeeBenefits = _employeeBenefitService.GetAll();
        return Ok(employeeBenefits);
    }

    /// <summary>
    /// Получает льготу сотрудника по уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор льготы.</param>
    /// <returns>Льгота с указанным идентификатором или 404, если не найдена.</returns>
    [HttpGet("{id}")]
    public ActionResult<EmployeeBenefitGetDto> Get(int id)
    {
        var employeeBenefit = _employeeBenefitService.GetById(id);
        if (employeeBenefit == null)
        {
            return NotFound($"Льгота с идентификатором {id} не найдена.");
        }
        return Ok(employeeBenefit);
    }

    /// <summary>
    /// Добавляет новую льготу для сотрудника.
    /// </summary>
    /// <param name="employeeBenefitDto">Данные для добавления новой льготы.</param>
    /// <returns>Статус 201 (Created) и добавленная льгота.</returns>
    [HttpPost]
    public ActionResult<EmployeeBenefitGetDto> Post([FromBody] EmployeeBenefitPostDto employeeBenefitDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newId = _employeeBenefitService.Post(employeeBenefitDto);
        var createdEmployeeBenefitDto = _employeeBenefitService.GetById(newId); 
        return CreatedAtAction(nameof(Get), new { id = newId }, createdEmployeeBenefitDto);
    }

    /// <summary>
    /// Обновляет информацию о существующей льготе сотрудника.
    /// </summary>
    /// <param name="id">Идентификатор льготы для обновления.</param>
    /// <param name="updatedEmployeeBenefitDto">Обновленная информация о льготе.</param>
    /// <returns>Статус 404, если льгота не найдена.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] EmployeeBenefitPostDto updatedEmployeeBenefitDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedEmployeeBenefit = _employeeBenefitService.Put(id, updatedEmployeeBenefitDto);
        if (updatedEmployeeBenefit == null)
        {
            return NotFound($"Льгота с идентификатором {id} не найдена.");
        }

        return NoContent();
    }

    /// <summary>
    /// Удаляет льготу сотрудника по уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор льготы для удаления.</param>
    /// <returns>Статус 404, если льгота не найдена.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var employeeBenefitExists = _employeeBenefitService.GetById(id);
        if (employeeBenefitExists == null)
        {
            return NotFound($"Льгота с идентификатором {id} не найдена.");
        }

        _employeeBenefitService.Delete(id);
        return NoContent();
    }
}