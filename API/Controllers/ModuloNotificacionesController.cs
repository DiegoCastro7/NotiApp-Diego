using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ModuloNotificacionesController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModuloNotificacionesController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModuloNotificacionesDto>>> Get()
    {
        var modulosnotificaciones = await _unitOfWork.ModulosNotificaciones.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<ModuloNotificacionesDto>>(modulosnotificaciones);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModuloNotificaciones>> Post(ModuloNotificacionesDto ModuloNotificacionesDto)
    {
        var modulonotificacion = _mapper.Map<ModuloNotificaciones>(ModuloNotificacionesDto);
        this._unitOfWork.ModulosNotificaciones.Add(modulonotificacion);
        await _unitOfWork.SaveAsync();
        if (modulonotificacion == null)
        {
            return BadRequest();
        }
        ModuloNotificacionesDto.Id = (int)modulonotificacion.Id;
        return CreatedAtAction(nameof(Post), new { id = ModuloNotificacionesDto.Id }, ModuloNotificacionesDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloNotificacionesDto>> Get(int id)
    {
        var modulonotificacion = await _unitOfWork.ModulosNotificaciones.GetByIdAsync(id);
        if (modulonotificacion == null){
            return NotFound();
        }
        return _mapper.Map<ModuloNotificacionesDto>(modulonotificacion);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModuloNotificacionesDto>> Put(int id, [FromBody] ModuloNotificacionesDto ModuloNotificacionesDto)
    {
        if (ModuloNotificacionesDto == null)
        {
            return NotFound();
        }
        var modulosnotificaciones = _mapper.Map<ModuloNotificaciones>(ModuloNotificacionesDto);
        _unitOfWork.ModulosNotificaciones.Update(modulosnotificaciones);
        await _unitOfWork.SaveAsync();
        return ModuloNotificacionesDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var modulonotificacion = await _unitOfWork.ModulosNotificaciones.GetByIdAsync(id);
        if (modulonotificacion == null)
        {
            return NotFound();
        }
        _unitOfWork.ModulosNotificaciones.Remove(modulonotificacion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}