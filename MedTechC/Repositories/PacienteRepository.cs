using MedTechC.Data;
using MedTechC.Models;
using MedTechC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedTechC.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly MedTechDbContext _dbContext;

        public PacienteRepository(MedTechDbContext medTechDbContext)
        {
            _dbContext = medTechDbContext;
        }

        public async Task<List<PacienteModel>> BuscarTodosPacientes()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }

        public async Task<PacienteModel> BuscarPacientePorId(int id)
        {
            return await _dbContext.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PacienteModel> AdicionarPaciente(PacienteModel paciente)
        {
            // Certifique-se de que o Id não seja definido explicitamente
            paciente.Id = 0;

            await _dbContext.Pacientes.AddAsync(paciente);
            await _dbContext.SaveChangesAsync();
            return paciente;
        }

        public async Task<PacienteModel> AtualizarPaciente(PacienteModel paciente, int id)
        {
            PacienteModel pacientePorId = await BuscarPacientePorId(id);
            if (BuscarPacientePorId == null)
            {
                throw new Exception($"Paciente {paciente.Nome} não encontrado no banco de dados");
            }
            pacientePorId.Nome = paciente.Nome;
            pacientePorId.Cpf = paciente.Cpf;
            pacientePorId.CartaoSus = paciente.CartaoSus;
            pacientePorId.Rg = paciente.Rg;
            pacientePorId.DataNascimento = paciente.DataNascimento;
            pacientePorId.Sexo = paciente.Sexo;
            pacientePorId.NomeMae = paciente.NomeMae;
            pacientePorId.NomePai = paciente.NomePai;
            pacientePorId.Telefone = paciente.Telefone;
            pacientePorId.Endereco = paciente.Endereco;
            pacientePorId.Observacoes = paciente.Observacoes;
            _dbContext.Pacientes.Update(pacientePorId);
            await _dbContext.SaveChangesAsync();

            return pacientePorId;
        }

        public async Task<bool> ExcluirPaciente(int id)
        {
            PacienteModel pacientePorId = await BuscarPacientePorId(id);
            if (BuscarPacientePorId == null)
            {
                throw new Exception($"Paciente {id} não encontrado no banco de dados");
            }

            _dbContext.Pacientes.Remove(pacientePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
