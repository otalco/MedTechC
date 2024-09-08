using MedTechC.Enums;
using MedTechC.Models;

namespace MedTechC.Repositories.Interfaces
{
    public interface IProntuarioRepository
    {
        Task<IEnumerable<ProntuarioModel>> GetAllProntuariosAsync();
        Task<ProntuarioModel> GetProntuarioByIdAsync(int id);
        Task<IEnumerable<ProntuarioModel>> GetProntuariosByPacienteIdAsync(int pacienteId);
        Task<IEnumerable<ProntuarioModel>> GetProntuariosByPacienteNomeAsync(string nome);
        Task<ProntuarioModel> AddProntuarioAsync(ProntuarioModel prontuario);
        Task<ProntuarioModel> UpdateProntuarioAsync(ProntuarioModel prontuario);
        Task<bool> DeleteProntuarioAsync(int id);
        Task<int?> GetPacienteIdByProntuarioIdAsync(int prontuarioId);
        Task<ProntuarioModel> GetNextProntuarioAsync();
        Task<bool> HasProntuarios(int pacienteId);
        Task<bool> UpdateProntuarioStatusAsync(int prontuarioId, StatusProntuario novoStatus);
    }
}
