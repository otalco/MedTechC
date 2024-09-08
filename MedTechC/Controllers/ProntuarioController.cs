using MedTechC.Models;
using MedTechC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedTechC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : ControllerBase
    {
        private readonly IProntuarioRepository _prontuarioRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public ProntuarioController(IProntuarioRepository prontuarioRepository, IPacienteRepository pacienteRepository)
        {
            _prontuarioRepository = prontuarioRepository;
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProntuarios()
        {
            var prontuarios = await _prontuarioRepository.GetAllProntuariosAsync();
            return Ok(prontuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProntuarioById(int id)
        {
            var prontuario = await _prontuarioRepository.GetProntuarioByIdAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }
            return Ok(prontuario);
        }

        [HttpGet("paciente/{pacienteId}")]
        public async Task<IActionResult> GetProntuariosByPacienteId(int pacienteId)
        {
            var prontuarios = await _prontuarioRepository.GetProntuariosByPacienteIdAsync(pacienteId);
            return Ok(prontuarios);
        }

        [HttpGet("paciente/nome/{nome}")]
        public async Task<IActionResult> GetProntuariosByPacienteNome(string nome)
        {
            var prontuarios = await _prontuarioRepository.GetProntuariosByPacienteNomeAsync(nome);
            return Ok(prontuarios);
        }

        [HttpPost]
        public async Task<IActionResult> AddProntuario([FromBody] ProntuarioModel prontuario)
        {
            if (prontuario == null)
            {
                return BadRequest();
            }

            var createdProntuario = await _prontuarioRepository.AddProntuarioAsync(prontuario);
            return CreatedAtAction(nameof(GetProntuarioById), new { id = createdProntuario.Id }, createdProntuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProntuario(int id, [FromBody] ProntuarioModel prontuario)
        {
            if (prontuario == null || prontuario.Id != id)
            {
                return BadRequest();
            }

            var updatedProntuario = await _prontuarioRepository.UpdateProntuarioAsync(prontuario);
            return Ok(updatedProntuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProntuario(int id)
        {
            var result = await _prontuarioRepository.DeleteProntuarioAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("next")]
        public async Task<IActionResult> GetNextProntuario()
        {
            // Obtenha o próximo prontuário
            var prontuario = await _prontuarioRepository.GetNextProntuarioAsync();
            if (prontuario == null)
            {
                Console.WriteLine("No prontuario found with Status.Aberto");
                return NotFound();
            }

            Console.WriteLine($"Prontuario found: {prontuario.Id}");

            // Obtenha o ID do paciente associado ao prontuário
            var pacienteId = await _prontuarioRepository.GetPacienteIdByProntuarioIdAsync(prontuario.Id);
            if (pacienteId == null)
            {
                Console.WriteLine($"No pacienteId found for ProntuarioId: {prontuario.Id}");
                return NotFound();
            }

            Console.WriteLine($"PacienteId found: {pacienteId}");

            // Obtenha o paciente associado ao ID
            var paciente = await _pacienteRepository.BuscarPacientePorId(pacienteId.Value);
            if (paciente == null)
            {
                Console.WriteLine($"No paciente found for PacienteId: {pacienteId}");
                return NotFound();
            }

            Console.WriteLine($"Paciente found: {paciente.Id}, Nome: {paciente.Nome}");

            // Crie o resultado a ser retornado
            var result = new
            {
                prontuario.Id,
                prontuario.Urgencia,
                prontuario.Status,
                NomePaciente = paciente.Nome
            };

            // Retorne o resultado
            return Ok(result);
        }
    }   
}
