using Microsoft.AspNetCore.Mvc;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service;
using System.Collections.Generic;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления сотрудниками.
/// Предоставляет методы для получения, добавления, обновления и удаления сотрудников.
/// </summary>
[Route("[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IService<EmployeeGetDto, EmployeePostDto> _service; 

    public EmployeeController(IService<EmployeeGetDto, EmployeePostDto> service) => _service = service; 

    /// <summary>
    /// Получает список всех сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeGetDto>> Get()
    {
        var employees = _service.GetAll();
        return Ok(employees);
    }

    /// <summary>
    /// Получает сотрудника по его уникальному идентификатору.
    /// </summary>
    /// <returns>Сотрудник с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id:int}")]
    public ActionResult<EmployeeGetDto> Get(int id)
    {
        var employee = _service.GetById(id);
        if (employee == null)
        {
            return NotFound($"Сотрудник с id {id} не найден.");
        }
        return Ok(employee);
    }

    /// <summary>
    /// Добавляет нового сотрудника.
    /// </summary>
    /// <returns>Статус 201 (Created) и добавленный сотрудник.</returns>
    [HttpPost]
    public ActionResult<EmployeeGetDto> Post([FromBody] EmployeePostDto employeeDto)
    {
        if (employeeDto == null)
        {
            return BadRequest("Сотрудник не может быть null.");
        }

        try
        {
            var newId = _service.Post(employeeDto);
            var createdEmployee = _service.GetById(newId);
            return CreatedAtAction(nameof(Get), new { id = newId }, createdEmployee);
        }
        catch (Exception)
        {
            return StatusCode(500, "Внутренняя ошибка сервера.");
        }
    }

    /// <summary>
    /// Обновляет информацию о существующем сотруднике.
    /// </summary>
    /// <returns>Обновленный сотрудник или статус 404, если не найден.</returns>
    [HttpPut("{id:int}")]
    public ActionResult<EmployeeGetDto> Put(int id, [FromBody] EmployeePostDto updatedEmployeeDto)
    {
        if (updatedEmployeeDto == null)
        {
            return BadRequest("Обновленный сотрудник не может быть null.");
        }

        var updatedEmployee = _service.Put(id, updatedEmployeeDto);
        if (updatedEmployee == null)
        {
            return NotFound($"Сотрудник с id {id} не найден для обновления.");
        }

        return Ok(updatedEmployee);
    }

    /// <summary>
    /// Удаляет сотрудника по его уникальному идентификатору.
    /// </summary>
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        if (_service.GetById(id) is null)
        {
            return NotFound($"Сотрудник с id {id} не найден.");
        }

        _service.Delete(id);
        return NoContent();
    }
}