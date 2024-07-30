using MedTechC.Models;
using MedTechC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedTechC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepositorie;

        public PacienteController(IPacienteRepository pacienteRepositorie)
        {
            _pacienteRepositorie = pacienteRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<PacienteModel>>> RetornaTodosOsPaciente()
        {
            List<PacienteModel> paciente = await _pacienteRepositorie.BuscarTodosPacientes();
            return Ok(paciente);
        }

        [HttpGet("{pacienteId}")]
        public async Task<ActionResult<PacienteModel>> RetornaTodosOsPaciente(int pacienteId)
        {
            PacienteModel paciente = await _pacienteRepositorie.BuscarPacientePorId(pacienteId);
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<PacienteModel>> CadastrarPaciente([FromBody] PacienteModel paciente)
        {
            PacienteModel pacienteAdicionado = await _pacienteRepositorie.AdicionarPaciente(paciente);
            return Ok(pacienteAdicionado);
        }

        [HttpPut("{pacienteId}")]
        public async Task<ActionResult<PacienteModel>> AtualizarPaciente([FromBody] PacienteModel paciente,
            int pacienteId)
        {
            PacienteModel pacienteAtualizado = await _pacienteRepositorie.AtualizarPaciente(paciente, pacienteId);
            return Ok(pacienteAtualizado);
        }

        [HttpDelete("{pacienteId}")]
        public async Task<ActionResult<bool>> ExcluirPaciente(int pacienteId)
        {
            bool pacienteExcluido = await _pacienteRepositorie.ExcluirPaciente(pacienteId);
            return Ok(pacienteExcluido);
        }
    }
}
