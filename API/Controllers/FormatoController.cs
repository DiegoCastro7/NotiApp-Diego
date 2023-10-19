using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class FormatoController : BaseController
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FormatoController(IUnityOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<FormatosDto>>> Get()
    {
        var formatos = await _unitOfWork.Formatos.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<FormatosDto>>(formatos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Formatos>> Post(FormatosDto FormatosDto)
    {
        var formato = _mapper.Map<Formatos>(FormatosDto);
        this._unitOfWork.Formatos.Add(formato);
        await _unitOfWork.SaveAsync();
        if (formato == null)
        {
            return BadRequest();
        }
        FormatosDto.Id = (int)formato.Id;
        return CreatedAtAction(nameof(Post), new { id = FormatosDto.Id }, FormatosDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FormatosDto>> Get(int id)
    {
        var formato = await _unitOfWork.Formatos.GetByIdAsync(id);
        if (formato == null){
            return NotFound();
        }
        return _mapper.Map<FormatosDto>(formato);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<FormatosDto>> Put(int id, [FromBody] FormatosDto FormatosDto)
    {
        if (FormatosDto == null)
        {
            return NotFound();
        }
        var formatos = _mapper.Map<Formatos>(FormatosDto);
        _unitOfWork.Formatos.Update(formatos);
        await _unitOfWork.SaveAsync();
        return FormatosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var formato = await _unitOfWork.Formatos.GetByIdAsync(id);
        if (formato == null)
        {
            return NotFound();
        }
        _unitOfWork.Formatos.Remove(formato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}