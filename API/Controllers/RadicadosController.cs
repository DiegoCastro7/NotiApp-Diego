using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RadicadosController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RadicadosController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RadicadosDto>>> Get()
    {
        var radicados = await _unitOfWork.Radicados.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<RadicadosDto>>(radicados);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Radicados>> Post(RadicadosDto radicadoDto)
    {
        var radicado = _mapper.Map<Radicados>(radicadoDto);
        this._unitOfWork.Radicados.Add(radicado);
        await _unitOfWork.SaveAsync();
        if (radicado == null)
        {
            return BadRequest();
        }
        radicadoDto.Id = (int)radicado.Id;
        return CreatedAtAction(nameof(Post), new { id = radicadoDto.Id }, radicadoDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RadicadosDto>> Get(int id)
    {
        var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
        if (radicado == null)
        {
            return NotFound();
        }
        return _mapper.Map<RadicadosDto>(radicado);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RadicadosDto>> Put(int id, [FromBody] RadicadosDto radicadoDto)
    {
        if (radicadoDto == null)
        {
            return NotFound();
        }
        var radicados = _mapper.Map<Radicados>(radicadoDto);
        _unitOfWork.Radicados.Update(radicados);
        await _unitOfWork.SaveAsync();
        return radicadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
        if (radicado == null)
        {
            return NotFound();
        }
        _unitOfWork.Radicados.Remove(radicado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}