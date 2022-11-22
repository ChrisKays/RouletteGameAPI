using RouletteGameApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Repositories.Interface
{
    public interface ISpinRepository
    {
        Task<IEnumerable<Spin>> GetAllSpinsAsync();
        Task<Spin> GetSpinAsync(int spinId);
        Task<Spin> GetNextSpinAsync(int betId);
    }
}
