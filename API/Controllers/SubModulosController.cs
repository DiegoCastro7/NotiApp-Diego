using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SubmoduloController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubmoduloController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubmodulosDto>>> Get()
    {
        var Submodulos = await _unitOfWork.Submodulos.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<SubmodulosDto>>(Submodulos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Submodulos>> Post(SubmodulosDto submoduloDto)
    {
        var submodulo = _mapper.Map<Submodulos>(submoduloDto);
        this._unitOfWork.Submodulos.Add(submodulo);
        await _unitOfWork.SaveAsync();
        if (submodulo == null)
        {
            return BadRequest();
        }
        submoduloDto.Id = (int)submodulo.Id;
        return CreatedAtAction(nameof(Post), new { id = submoduloDto.Id }, submoduloDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubmodulosDto>> Get(int id)
    {
        var submodulo = await _unitOfWork.Submodulos.GetByIdAsync(id);
        if (submodulo == null)
        {
            return NotFound();
        }
        return _mapper.Map<SubmodulosDto>(submodulo);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubmodulosDto>> Put(int id, [FromBody] SubmodulosDto submoduloDto)
    {
        if (submoduloDto == null)
        {
            return NotFound();
        }
        var Submodulos = _mapper.Map<Submodulos>(submoduloDto);
        _unitOfWork.Submodulos.Update(Submodulos);
        await _unitOfWork.SaveAsync();
        return submoduloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var submodulo = await _unitOfWork.Submodulos.GetByIdAsync(id);
        if (submodulo == null)
        {
            return NotFound();
        }
        _unitOfWork.Submodulos.Remove(submodulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

