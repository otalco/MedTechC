using MedTechC.Data;
using MedTechC.Models;
using MedTechC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CondutaRepository : ICondutaRepository
{
    private readonly MedTechDbContext _dbContext;

    public CondutaRepository(MedTechDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CondutaModel>> GetAllCondutasAsync()
    {
        return await _dbContext.Condutas.ToListAsync();
    }

    public async Task<CondutaModel> GetCondutaByIdAsync(int id)
    {
        return await _dbContext.Condutas.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CondutaModel> AddCondutaAsync(CondutaModel conduta)
    {
        await _dbContext.Condutas.AddAsync(conduta);
        await _dbContext.SaveChangesAsync();
        return conduta;
    }

    public async Task<CondutaModel> UpdateCondutaAsync(CondutaModel conduta)
    {
        _dbContext.Condutas.Update(conduta);
        await _dbContext.SaveChangesAsync();
        return conduta;
    }

    public async Task<bool> DeleteCondutaAsync(int id)
    {
        var conduta = await _dbContext.Condutas.FindAsync(id);
        if (conduta == null)
        {
            return false;
        }

        _dbContext.Condutas.Remove(conduta);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> HasCondutas(int pacienteId)
    {
        return await _dbContext.Condutas.AnyAsync(c => c.PacienteId == pacienteId);
    }
}
