using Microsoft.AspNetCore.Mvc;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service;
using System.Collections.Generic;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления цехами на предприятии.
/// Предоставляет методы для получения, добавления, обновления и удаления цехов.
/// </summary>
[Route("[controller]")]
[ApiController]
public class WorkshopController(IService<WorkshopGetDto, WorkshopPostDto> service) : ControllerBase
{
    /// <summary>
    /// Получает список всех цехов на предприятии.
    /// </summary>
    /// <returns>Список цехов.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<WorkshopGetDto>> Get()
    {
        var workshopDtos = service.GetAll();
        return Ok(workshopDtos);
    }

    /// <summary>
    /// Получает цех по указанному идентификатору.
    /// </summary>
    /// <returns>Цех с указанным идентификатором или 404, если не найден.</returns>
    [HttpGet("{id}")]
    public ActionResult<WorkshopGetDto> Get(int id)
    {
        var workshopDto = service.GetById(id);
        if (workshopDto == null)
        {
            return NotFound($"Цех с идентификатором {id} не найден.");
        }
        return Ok(workshopDto);
    }

    /// <summary>
    /// Добавляет новый цех на предприятии.
    /// </summary>
    /// <returns>Статус 201 (Created) и добавленный цех.</returns>
    [HttpPost]
    public ActionResult<WorkshopGetDto> Post([FromBody] WorkshopPostDto workshopDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newId = service.Post(workshopDto);
        var createdWorkshopDto = service.GetById(newId);
        return CreatedAtAction(nameof(Get), new { id = newId }, createdWorkshopDto);
    }

    /// <summary>
    /// Обновляет информацию о цехе по указанному идентификатору.
    /// </summary>
    /// <returns>Статус 204 No Content или 404, если цех не найден.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] WorkshopPostDto updatedWorkshopDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedWorkshop = service.Put(id, updatedWorkshopDto);
        if (updatedWorkshop == null)
        {
            return NotFound($"Цех с идентификатором {id} не найден.");
        }

        return NoContent();
    }

    /// <summary>
    /// Удаляет цех по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор цеха для удаления.</param>
    /// <returns>Статус 204 No Content или 404, если цех не найден.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var workshopExists = service.GetById(id);
        if (workshopExists == null)
        {
            return NotFound($"Цех с идентификатором {id} не найден.");
        }

        service.Delete(id);
        return NoContent();
    }
}