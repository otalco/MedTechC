using MedTechC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICondutaRepository
{
    Task<IEnumerable<CondutaModel>> GetAllCondutasAsync();
    Task<CondutaModel> GetCondutaByIdAsync(int id);
    Task<CondutaModel> AddCondutaAsync(CondutaModel conduta);
    Task<CondutaModel> UpdateCondutaAsync(CondutaModel conduta);
    Task<bool> DeleteCondutaAsync(int id);
    Task<bool> HasCondutas(int pacienteId);
}
