using Microsoft.AspNetCore.Mvc;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service;
using Microsoft.Extensions.Logging;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления сотрудниками.
/// Предоставляет методы для получения, добавления, обновления и удаления сотрудников.
/// </summary>
[Route("[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;
    private readonly ILogger<EmployeeController> _logger; 

    /// <summary>
    /// Инициализирует новый экземпляр контроллера сотрудников.
    /// </summary>
    public EmployeeController(EmployeeService employeeService, ILogger<EmployeeController> logger)
    {
        _employeeService = employeeService; 
        _logger = logger;
    }

    /// <summary>
    /// Получает список всех сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeGetDto>> Get()
    {
        var employees = _employeeService.GetAll();
        return Ok(employees);
    }

    /// <summary>
    /// Получает сотрудника по его уникальному идентификатору.
    /// </summary>
    /// <returns>Сотрудник с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id:int}")]
    public ActionResult<EmployeeGetDto> Get(int id)
    {
        var employee = _employeeService.GetById(id);
        if (employee == null)
        {
            _logger.LogWarning($"Сотрудник с id {id} не найден.");
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
            var newId = _employeeService.Post(employeeDto);
            var createdEmployee = _employeeService.GetById(newId);
            return CreatedAtAction(nameof(Get), new { id = newId }, createdEmployee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при добавлении нового сотрудника.");
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

        var updatedEmployee = _employeeService.Put(id, updatedEmployeeDto);
        if (updatedEmployee == null)
        {
            _logger.LogWarning($"Сотрудник с id {id} не найден для обновления.");
            return NotFound($"Сотрудник с id {id} не найден.");
        }

        return Ok(updatedEmployee);
    }

    /// <summary>
    /// Удаляет сотрудника по его уникальному идентификатору.
    /// </summary>
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var employeeExists = _employeeService.GetById(id);
        if (employeeExists == null)
        {
            _logger.LogWarning($"Сотрудник с id {id} не найден для удаления.");
            return NotFound($"Сотрудник с id {id} не найден .");
        }

        try
        {
            _employeeService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при удалении сотрудника с id {id}.");
            return StatusCode(500, "Внутренняя ошибка сервера.");
        }
    }
}