using Microsoft.AspNetCore.Mvc;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service;
using System.Collections.Generic;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления связями между сотрудниками и должностями.
/// Предоставляет методы для получения, добавления, обновления и удаления связей.
/// </summary>
[Route("[controller]")]
[ApiController]
public class EmployeePositionController : ControllerBase
{
    private readonly IService<EmployeePositionGetDto, EmployeePositionPostDto> _service; 

    public EmployeePositionController(IService<EmployeePositionGetDto, EmployeePositionPostDto> service) => _service = service; 

    /// <summary>
    /// Получает список всех связей между сотрудниками и должностями.
    /// </summary>
    /// <returns>Список связей между сотрудниками и должностями.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<EmployeePositionGetDto>> Get()
    {
        var employeePositionDtos = _service.GetAll();
        return Ok(employeePositionDtos);
    }

    /// <summary>
    /// Получает связь между сотрудником и должностью по указанному идентификатору.
    /// </summary>
    /// <returns>Связь между сотрудником и должностью с указанным идентификатором или 404, если не найдена.</returns>
    [HttpGet("{id}")]
    public ActionResult<EmployeePositionGetDto> Get(int id)
    {
        var employeePositionDto = _service.GetById(id);
        if (employeePositionDto == null)
        {
            return NotFound($"Связь между сотрудником и должностью по идентификатору {id} не найдена.");
        }
        return Ok(employeePositionDto);
    }

    /// <summary>
    /// Добавляет новую связь между сотрудником и должностью.
    /// </summary>
    /// <returns>Статус 201 (Created) и добавленная связь.</returns>
    [HttpPost]
    public ActionResult<EmployeePositionGetDto> Post([FromBody] EmployeePositionPostDto employeePositionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newId = _service.Post(employeePositionDto);
        var createdEmployeePositionDto = _service.GetById(newId);
        return CreatedAtAction(nameof(Get), new { id = newId }, createdEmployeePositionDto);
    }

    /// <summary>
    /// Обновляет информацию о связи между сотрудником и должностью по указанному идентификатору.
    /// </summary>
    /// <returns>Статус 204 No Content или 404, если связь не найдена.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] EmployeePositionPostDto updatedEmployeePositionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedEmployeePosition = _service.Put(id, updatedEmployeePositionDto);
        if (updatedEmployeePosition == null)
        {
            return NotFound($"Связь между сотрудником и должностью по идентификатору {id} не найдена.");
        }

        return NoContent();
    }

    /// <summary>
    /// Удаляет связь между сотрудником и должностью по указанному идентификатору.
    /// </summary>
    /// <returns>Статус 204 No Content или 404, если связь не найдена.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var employeePositionExists = _service.GetById(id);
        if (employeePositionExists == null)
        {
            return NotFound($"Связь между сотрудником и должностью по идентификатору {id} не найдена.");
        }

        _service.Delete(id);
        return NoContent();
    }
}