using MedTechC.Data;
using MedTechC.Models;
using MedTechC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedTechC.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly MedTechDbContext _dbContext;

        public ProntuarioRepository(MedTechDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProntuarioModel>> GetAllProntuariosAsync()
        {
            return await _dbContext.Prontuarios.ToListAsync();
        }

        public async Task<ProntuarioModel> GetProntuarioByIdAsync(int id)
        {
            return await _dbContext.Prontuarios.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProntuarioModel>> GetProntuariosByPacienteIdAsync(int pacienteId)
        {
            return await _dbContext.Prontuarios.Where(p => p.PacienteId == pacienteId).ToListAsync();
        }

        public async Task<IEnumerable<ProntuarioModel>> GetProntuariosByPacienteNomeAsync(string nome)
        {
            return await _dbContext.Prontuarios
                .Where(p => _dbContext.Pacientes.Any(pa => pa.Id == p.PacienteId && pa.Nome.Contains(nome)))
                .ToListAsync();
        }

        public async Task<ProntuarioModel> AddProntuarioAsync(ProntuarioModel prontuario)
        {
            await _dbContext.Prontuarios.AddAsync(prontuario);
            await _dbContext.SaveChangesAsync();
            return prontuario;
        }

        public async Task<ProntuarioModel> UpdateProntuarioAsync(ProntuarioModel prontuario)
        {
            _dbContext.Prontuarios.Update(prontuario);
            await _dbContext.SaveChangesAsync();
            return prontuario;
        }

        public async Task<bool> DeleteProntuarioAsync(int id)
        {
            var prontuario = await _dbContext.Prontuarios.FindAsync(id);
            if (prontuario == null)
            {
                return false;
            }

            _dbContext.Prontuarios.Remove(prontuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProntuarioModel> GetNextProntuarioAsync()
        {
            return await _dbContext.Prontuarios
                .OrderBy(p => p.Status)
                .ThenBy(p => p.DataAtendimento)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> HasProntuarios(int pacienteId)
        {
            return await _dbContext.Prontuarios.AnyAsync(p => p.PacienteId == pacienteId);
        }
    }
}

