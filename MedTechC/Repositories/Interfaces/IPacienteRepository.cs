using MedTechC.Models;

namespace MedTechC.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<PacienteModel>> BuscarTodosPacientes();
        Task<PacienteModel> BuscarPacientePorId(int id);
        Task<PacienteModel> AdicionarPaciente(PacienteModel paciente);
        Task<PacienteModel> AtualizarPaciente(PacienteModel paciente, int id);
        Task<bool> ExcluirPaciente(int id);
    }
}
