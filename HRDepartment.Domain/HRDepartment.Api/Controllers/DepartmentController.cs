using Microsoft.AspNetCore.Mvc;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service;
using System.Collections.Generic;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления отделами.
/// Предоставляет методы для получения, добавления, обновления и удаления отделов.
/// </summary>
[Route("[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService) => _departmentService = departmentService;

    /// <summary>
    /// Получает список всех отделов.
    /// </summary>
    /// <returns>Список отделов.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<DepartmentGetDto>> Get()
    {
        var departments = _departmentService.GetAll();
        return Ok(departments);
    }

    /// <summary>
    /// Получает отдел по уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела.</param>
    /// <returns>Отдел с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id}")]
    public ActionResult<DepartmentGetDto> Get(int id)
    {
        var department = _departmentService.GetById(id);
        if (department == null)
        {
            return NotFound($"Отдел с идентификатором {id} не найден.");
        }
        return Ok(department);
    }

    /// <summary>
    /// Добавляет новый отдел.
    /// </summary>
    /// <param name="departmentDto">Отдел для добавления.</param>
    /// <returns>Статус 201 (Created) и добавленный отдел.</returns>
    [HttpPost]
    public ActionResult<DepartmentGetDto> Post([FromBody] DepartmentPostDto departmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newId = _departmentService.Post(departmentDto);
        var createdDepartmentDto = _departmentService.GetById(newId); // Получаем созданный объект
        return CreatedAtAction(nameof(Get), new { id = newId }, createdDepartmentDto);
    }

    /// <summary>
    /// Обновляет информацию о существующем отделе.
    /// </summary>
    /// <param name="id">Иден тификатор отдела для обновления.</param>
    /// <param name="updatedDepartment">Обновленная информация о отделе.</param>
    /// <returns>Статус 404, если отдел не найден.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] DepartmentPostDto updatedDepartmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedDepartment = _departmentService.Put(id, updatedDepartmentDto);
        if (updatedDepartment == null)
        {
            return NotFound($"Отдел с идентификатором {id} не найден.");
        }

        return NoContent();
    }

    /// <summary>
    /// Удаляет отдел по уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела для удаления.</param>
    /// <returns>Статус 404, если отдел не найден.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var departmentExists = _departmentService.GetById(id);
        if (departmentExists == null)
        {
            return NotFound($"Отдел с идентификатором {id} не найден.");
        }

        _departmentService.Delete(id);
        return NoContent();
    }
}