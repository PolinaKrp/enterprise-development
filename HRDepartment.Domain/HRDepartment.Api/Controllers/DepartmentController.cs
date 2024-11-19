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
    private readonly IService<DepartmentGetDto, DepartmentPostDto> _service;

    public DepartmentController(IService<DepartmentGetDto, DepartmentPostDto> service) => _service = service; 

    /// <summary>
    /// Получает список всех отделов.
    /// </summary>
    /// <returns>Список отделов.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<DepartmentGetDto>> Get()
    {
        var departments = _service.GetAll();
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
        var department = _service.GetById(id);
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
        if (departmentDto == null)
        {
            return BadRequest("Отдел не может быть null.");
        }

        var newId = _service.Post(departmentDto);
        var createdDepartmentDto = _service.GetById(newId); 
        return CreatedAtAction(nameof(Get), new { id = newId }, createdDepartmentDto);
    }

    /// <summary>
    /// Обновляет информацию о существующем отделе.
    /// </summary>
    /// <param name="id">Идентификатор отдела для обновления.</param>
    /// <param name="updatedDepartmentDto">Обновленная информация о отделе.</param>
    /// <returns>Статус 404, если отдел не найден.</returns>
    [HttpPut("{id}")]
    public ActionResult<DepartmentGetDto> Put(int id, [FromBody] DepartmentPostDto updatedDepartmentDto)
    {
        if (updatedDepartmentDto == null)
        {
            return BadRequest("Отдел не может быть null.");
        }

        var updatedDepartment = _service.Put(id, updatedDepartmentDto);
        if (updatedDepartment == null)
        {
            return NotFound($"Отдел с идентификатором {id} не найден.");
        }

        return Ok(updatedDepartment);
    }

    /// <summary>
    /// Удаляет отдел по уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела для удаления.</param>
    /// <returns>Статус 404, если отдел не найден.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var isDeleted = _service.Delete(id);
        if (!isDeleted)
        {
            return NotFound($"Отдел с идентификатором {id} не найден.");
        }

        return Ok($"Отдел с идентификатором {id} удалён.");
    }
}