﻿using Microsoft.AspNetCore.Mvc;
using HRDepartment.Api.Dto;
using HRDepartment.Api.Service;
using System.Collections.Generic;

namespace HRDepartment.Api.Controllers;

/// <summary>
/// Контроллер для управления должностями на предприятии.
/// Предоставляет методы для получения, добавления, обновления и удаления должностей.
/// </summary>
[Route("[controller]")]
[ApiController]
public class PositionController : ControllerBase
{
    private readonly PositionService _positionService;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера должностей.
    /// </summary>
    public PositionController(PositionService positionService)
    {
        _positionService = positionService; 
    }

    /// <summary>
    /// Получает список всех должностей на предприятии.
    /// </summary>
    /// <returns>Список должностей.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PositionGetDto>> Get()
    {
        var positionDtos = _positionService.GetAll();
        return Ok(positionDtos);
    }

    /// <summary>
    /// Получает должность по указанному идентификатору.
    /// </summary>
    /// <returns>Должность с указанным идентификатором или 404, если не найдена.</returns>
    [HttpGet("{id}")]
    public ActionResult<PositionGetDto> Get(int id)
    {
        var positionDto = _positionService.GetById(id);
        if (positionDto == null)
        {
            return NotFound($"Должность с идентификатором {id} не найдена.");
        }
        return Ok(positionDto);
    }

    /// <summary>
    /// Добавляет новую должность на предприятии.
    /// </summary>
    /// <returns>Статус 201 (Created) и добавленная должность.</returns>
    [HttpPost]
    public ActionResult<PositionGetDto> Post([FromBody] PositionPostDto positionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newId = _positionService.Post(positionDto);
        var createdPositionDto = _positionService.GetById(newId);
        return CreatedAtAction(nameof(Get), new { id = newId }, createdPositionDto);
    }

    /// <summary>
    /// Обновляет информацию о должности по указанному идентификатору.
    /// </summary>
    /// <returns>Статус 204 No Content или 404, если должность не найдена.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] PositionPostDto updatedPositionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedPosition = _positionService.Put(id, updatedPositionDto);
        if (updatedPosition == null)
        {
            return NotFound($"Должность с идентификатором {id} не найдена.");
        }

        return NoContent(); 
    }

    /// <summary>
    /// Удаляет должность по указанному идентификатору.
    /// </summary>
    /// <returns>Статус 204 No Content или 404, если должность не найдена.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var positionExists = _positionService.GetById(id);
        if (positionExists == null)
        {
            return NotFound($"Должность с идентификатором {id} не найдена.");
        }

        _positionService.Delete(id);
        return NoContent(); 
    }
}