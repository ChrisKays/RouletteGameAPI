using AutoMapper;
using RouletteGameApi.DataObjects;
using RouletteGameApi.Models;
using RouletteGameApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Services
{
    public class BetService : Repository<BetInfo>, IBet
    {
        private readonly RouletteGameContext _db;
        private readonly IMapper _mapper;
        public BetService(RouletteGameContext db, IMapper mapper)
         : base(db)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<BetInfo> GetBet(int betId)
        {
            var result = await GetAllAsync(i => i.Id == betId);
            if (result.Count == 0) return null;
            var myBet = result.Find(i => i.Id == betId);
            return myBet;
        }
        public async Task<IEnumerable<BetInfo>> GetBetCol()
        {           
            var result = await GetAllAsync();
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<BetDto> PlaceBetAsync(BetInfo placedBet)
		{
            var myBet = _mapper.Map<BetInfo>(placedBet);

            using (_db)
            {
                Random random = new Random();
                int i = random.Next();
                myBet.Id = i;
                var add = await AddAsync(myBet);
            }

            var result = _mapper.Map<BetDto>(myBet);

            return result;
        }
	}
}
