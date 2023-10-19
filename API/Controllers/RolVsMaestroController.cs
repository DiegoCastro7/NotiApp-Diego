using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RolVsMaestroController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolVsMaestroController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolVsMaestroDto>>> Get()
    {
        var RolVsMaestros = await _unitOfWork.RolVsMaestros.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<RolVsMaestroDto>>(RolVsMaestros);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolVsMaestro>> Post(RolVsMaestroDto RolVsMaestroDto)
    {
        var RolVsMaestro = _mapper.Map<RolVsMaestro>(RolVsMaestroDto);
        this._unitOfWork.RolVsMaestros.Add(RolVsMaestro);
        await _unitOfWork.SaveAsync();
        if (RolVsMaestro == null)
        {
            return BadRequest();
        }
        RolVsMaestroDto.Id = (int)RolVsMaestro.Id;
        return CreatedAtAction(nameof(Post), new { id = RolVsMaestroDto.Id }, RolVsMaestroDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolVsMaestroDto>> Get(int id)
    {
        var RolVsMaestro = await _unitOfWork.RolVsMaestros.GetByIdAsync(id);
        if (RolVsMaestro == null)
        {
            return NotFound();
        }
        return _mapper.Map<RolVsMaestroDto>(RolVsMaestro);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolVsMaestroDto>> Put(int id, [FromBody] RolVsMaestroDto RolVsMaestroDto)
    {
        if (RolVsMaestroDto == null)
        {
            return NotFound();
        }
        var RolVsMaestros = _mapper.Map<RolVsMaestro>(RolVsMaestroDto);
        _unitOfWork.RolVsMaestros.Update(RolVsMaestros);
        await _unitOfWork.SaveAsync();
        return RolVsMaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var RolVsMaestro = await _unitOfWork.RolVsMaestros.GetByIdAsync(id);
        if (RolVsMaestro == null)
        {
            return NotFound();
        }
        _unitOfWork.RolVsMaestros.Remove(RolVsMaestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}


