using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoNotificacionesController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoNotificacionesController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoNotificacionesDto>>> Get()
    {
        var tiposnotificaciones = await _unitOfWork.TiposNotificaciones.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<TipoNotificacionesDto>>(tiposnotificaciones);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoNotificaciones>> Post(TipoNotificacionesDto tiponotificacionDto)
    {
        var tiponotificacion = _mapper.Map<TipoNotificaciones>(tiponotificacionDto);
        this._unitOfWork.TiposNotificaciones.Add(tiponotificacion);
        await _unitOfWork.SaveAsync();
        if (tiponotificacion == null)
        {
            return BadRequest();
        }
        tiponotificacionDto.Id = (int)tiponotificacion.Id;
        return CreatedAtAction(nameof(Post), new { id = tiponotificacionDto.Id }, tiponotificacionDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNotificacionesDto>> Get(int id)
    {
        var tiponotificacion = await _unitOfWork.TiposNotificaciones.GetByIdAsync(id);
        if (tiponotificacion == null)
        {
            return NotFound();
        }
        return _mapper.Map<TipoNotificacionesDto>(tiponotificacion);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoNotificacionesDto>> Put(int id, [FromBody] TipoNotificacionesDto tiponotificacionDto)
    {
        if (tiponotificacionDto == null)
        {
            return NotFound();
        }
        var tiposnotificaciones = _mapper.Map<TipoNotificaciones>(tiponotificacionDto);
        _unitOfWork.TiposNotificaciones.Update(tiposnotificaciones);
        await _unitOfWork.SaveAsync();
        return tiponotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tiponotificacion = await _unitOfWork.TiposNotificaciones.GetByIdAsync(id);
        if (tiponotificacion == null)
        {
            return NotFound();
        }
        _unitOfWork.TiposNotificaciones.Remove(tiponotificacion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

