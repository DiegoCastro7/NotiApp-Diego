using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PermisosGenericoController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PermisosGenericoController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PermisosGenericosDto>>> Get()
    {
        var permisosgenericos = await _unitOfWork.PermisosGenericos.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PermisosGenericosDto>>(permisosgenericos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermisosGenericos>> Post(PermisosGenericosDto permisogenericoDto)
    {
        var permisogenerico = _mapper.Map<PermisosGenericos>(permisogenericoDto);
        this._unitOfWork.PermisosGenericos.Add(permisogenerico);
        await _unitOfWork.SaveAsync();
        if (permisogenerico == null)
        {
            return BadRequest();
        }
        permisogenericoDto.Id = (int)permisogenerico.Id;
        return CreatedAtAction(nameof(Post), new { id = permisogenericoDto.Id }, permisogenericoDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisosGenericosDto>> Get(int id)
    {
        var permisogenerico = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if (permisogenerico == null)
        {
            return NotFound();
        }
        return _mapper.Map<PermisosGenericosDto>(permisogenerico);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermisosGenericosDto>> Put(int id, [FromBody] PermisosGenericosDto permisogenericoDto)
    {
        if (permisogenericoDto == null)
        {
            return NotFound();
        }
        var permisosgenericos = _mapper.Map<PermisosGenericos>(permisogenericoDto);
        _unitOfWork.PermisosGenericos.Update(permisosgenericos);
        await _unitOfWork.SaveAsync();
        return permisogenericoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var permisogenerico = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if (permisogenerico == null)
        {
            return NotFound();
        }
        _unitOfWork.PermisosGenericos.Remove(permisogenerico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}