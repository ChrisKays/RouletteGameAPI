using RouletteGameApi.Models;
using System.Threading.Tasks;

namespace RouletteGameApi.Repositories.Interface
{
    public interface IBetRepository
    {
        Task<BetInfo> GetBetAsync(int betId);
    }
}
