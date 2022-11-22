using AutoMapper;
using RouletteGameApi.DataObjects;
using RouletteGameApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Services
{
    public interface ISpin
    {
        Task<IEnumerable<SpinDto>> GetAllSpinsAsync();
        Task<SpinDto> DoSpinAsync(BetInfo bet, IPayout payout);
        Task<SpinDto> GetSpinAsync(int spinId);
    }
}
