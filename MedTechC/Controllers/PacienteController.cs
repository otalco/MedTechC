using MedTechC.Models;
using MedTechC.Repositories;
using MedTechC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedTechC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IProntuarioRepository _prontuarioRepository;
        private readonly ICondutaRepository _condutaRepository;

        public PacienteController(IPacienteRepository pacienteRepository, IProntuarioRepository prontuarioRepository, ICondutaRepository condutaRepository)
        {
            _pacienteRepository = pacienteRepository;
            _prontuarioRepository = prontuarioRepository;
            _condutaRepository = condutaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PacienteModel>>> RetornaTodosOsPacientes()
        {
            List<PacienteModel> pacientes = await _pacienteRepository.BuscarTodosPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{pacienteId}")]
        public async Task<ActionResult<PacienteModel>> RetornaPacientePorId(int pacienteId)
        {
            PacienteModel paciente = await _pacienteRepository.BuscarPacientePorId(pacienteId);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<PacienteModel>> CadastrarPaciente([FromBody] PacienteModel paciente)
        {
            paciente.Id = 0;
            PacienteModel pacienteAdicionado = await _pacienteRepository.AdicionarPaciente(paciente);
            return CreatedAtAction(nameof(RetornaPacientePorId), new { pacienteId = pacienteAdicionado.Id }, pacienteAdicionado);
        }

        [HttpPut("{pacienteId}")]
        public async Task<ActionResult<PacienteModel>> AtualizarPaciente([FromBody] PacienteModel paciente, int pacienteId)
        {
            if (pacienteId != paciente.Id)
            {
                return BadRequest("ID do paciente não corresponde ao ID na URL.");
            }

            PacienteModel pacienteAtualizado = await _pacienteRepository.AtualizarPaciente(paciente, pacienteId);
            if (pacienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(pacienteAtualizado);
        }

        [HttpDelete("{pacienteId}")]
        public async Task<ActionResult<bool>> ExcluirPaciente(int pacienteId)
        {
            bool hasProntuarios = await _prontuarioRepository.HasProntuarios(pacienteId);
            bool hasCondutas = await _condutaRepository.HasCondutas(pacienteId);

            if (hasProntuarios || hasCondutas)
            {
                return BadRequest("Não é possível excluir o paciente pois existem prontuários ou condutas registrados.");
            }

            bool pacienteExcluido = await _pacienteRepository.ExcluirPaciente(pacienteId);
            if (!pacienteExcluido)
            {
                return NotFound();
            }
            return Ok(pacienteExcluido);
        }
    }
}
