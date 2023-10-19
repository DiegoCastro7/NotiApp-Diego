using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class AuditoriaController : BaseController
{
    public IUnityOfWork _unityOfWork { get; }
    public IMapper _mapper { get; }
    public AuditoriaController(IUnityOfWork unityOfWork, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get()
    {
        var auditorias = await _unityOfWork.Auditorias.GetAllAsync();
        return _mapper.Map<List<AuditoriaDto>>(auditorias);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Auditoria>> Post(AuditoriaDto auditoriaDto)
    {
        var pais = _mapper.Map<Auditoria>(auditoriaDto);
        _unityOfWork.Auditorias.Add(pais);
        if (pais == null)
        {
            return BadRequest();
        }
        await _unityOfWork.SaveAsync();
        auditoriaDto.Id = pais.Id;
        return CreatedAtAction(nameof(Post), new { id = auditoriaDto.Id }, auditoriaDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuditoriaDto>> Get(int id)
    {
        var auditoria = await _unityOfWork.Auditorias.GetByIdAsync(id);
        if (auditoria == null)
        {
            return NotFound();
        }
        return _mapper.Map<AuditoriaDto>(auditoria);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AuditoriaDto>> Put(int id, [FromBody] AuditoriaDto auditoriaDto)
    {
        var auditoria = _mapper.Map<Auditoria>(auditoriaDto);
        if (auditoria == null)
            return NotFound();
        if (auditoria.Id == 0)
        {
            auditoria.Id = id;
        }
        if (auditoria.Id != id)
        {
            return BadRequest();
        }
        auditoria.Id = auditoria.Id;
        _unityOfWork.Auditorias.Update(auditoria);
        await _unityOfWork.SaveAsync();
        return auditoriaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var pais = await _unityOfWork.Auditorias.GetByIdAsync(id);
        if (pais == null)
        {
            return NotFound();
        }
        _unityOfWork.Auditorias.Remove(pais);
        await _unityOfWork.SaveAsync();
        return NoContent();
    }
}