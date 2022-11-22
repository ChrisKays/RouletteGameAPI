using AutoMapper;
using RouletteGameApi.DataObjects;
using RouletteGameApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Services
{
    public interface IBet
    {
        Task<BetInfo> GetBet(int id);
        Task<IEnumerable<BetInfo>> GetBetCol();
        Task<BetDto> PlaceBetAsync(BetInfo betForCreation);
    }
}
