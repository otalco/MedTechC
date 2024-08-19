using MedTechC.Models;
using MedTechC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CondutaController : ControllerBase
{
    private readonly ICondutaRepository _condutaRepository;

    public CondutaController(ICondutaRepository condutaRepository)
    {
        _condutaRepository = condutaRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CondutaModel>>> GetAllCondutas()
    {
        var condutas = await _condutaRepository.GetAllCondutasAsync();
        return Ok(condutas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CondutaModel>> GetCondutaById(int id)
    {
        var conduta = await _condutaRepository.GetCondutaByIdAsync(id);
        if (conduta == null)
        {
            return NotFound();
        }
        return Ok(conduta);
    }

    [HttpPost]
    public async Task<ActionResult<CondutaModel>> AddConduta(CondutaModel conduta)
    {
        var newConduta = await _condutaRepository.AddCondutaAsync(conduta);
        return CreatedAtAction(nameof(GetCondutaById), new { id = newConduta.Id }, newConduta);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CondutaModel>> UpdateConduta(int id, CondutaModel conduta)
    {
        if (id != conduta.Id)
        {
            return BadRequest();
        }

        var updatedConduta = await _condutaRepository.UpdateCondutaAsync(conduta);
        if (updatedConduta == null)
        {
            return NotFound();
        }

        return Ok(updatedConduta);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteConduta(int id)
    {
        var result = await _condutaRepository.DeleteCondutaAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
