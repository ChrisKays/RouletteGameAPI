using RouletteGameApi.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Services
{
    public interface IPayout
    {
        Task<IEnumerable<PayoutDto>> GetAllPayoutsBySpinBetAsync(int spinId, int betId);
        Task<IEnumerable<PayoutDto>> GetAllPayoutsAsync();
        Task<PayoutDto> GetPayoutAsync(int Id, int spinId, int betId);
        Task<PayoutDto> CreatePayout(int betId, int spinId, decimal amountToBePaid);
    }
}
