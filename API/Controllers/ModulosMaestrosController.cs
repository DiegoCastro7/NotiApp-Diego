using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ModulosMaestrosController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModulosMaestrosController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModulosMaestrosDto>>> Get()
    {
        var modulosmaestros = await _unitOfWork.ModulosMaestros.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<ModulosMaestrosDto>>(modulosmaestros);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModulosMaestros>> Post(ModulosMaestrosDto modulosmaestroDto)
    {
        var modulosmaestro = _mapper.Map<ModulosMaestros>(modulosmaestroDto);
        this._unitOfWork.ModulosMaestros.Add(modulosmaestro);
        await _unitOfWork.SaveAsync();
        if (modulosmaestro == null)
        {
            return BadRequest();
        }
        modulosmaestroDto.Id = (int)modulosmaestro.Id;
        return CreatedAtAction(nameof(Post), new { id = modulosmaestroDto.Id }, modulosmaestroDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModulosMaestrosDto>> Get(int id)
    {
        var modulosmaestro = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
        if (modulosmaestro == null)
        {
            return NotFound();
        }
        return _mapper.Map<ModulosMaestrosDto>(modulosmaestro);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModulosMaestrosDto>> Put(int id, [FromBody] ModulosMaestrosDto modulosmaestroDto)
    {
        if (modulosmaestroDto == null)
        {
            return NotFound();
        }
        var modulosmaestros = _mapper.Map<ModulosMaestros>(modulosmaestroDto);
        _unitOfWork.ModulosMaestros.Update(modulosmaestros);
        await _unitOfWork.SaveAsync();
        return modulosmaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var modulosmaestro = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
        if (modulosmaestro == null)
        {
            return NotFound();
        }
        _unitOfWork.ModulosMaestros.Remove(modulosmaestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}