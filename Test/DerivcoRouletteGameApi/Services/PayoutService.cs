using AutoMapper;
using RouletteGameApi.DataObjects;
using RouletteGameApi.Models;
using RouletteGameApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Services
{
    public class PayoutService : Repository<Payout>, IPayout
    {
        private readonly RouletteGameContext _db;
        private readonly IMapper _mapper;
        private readonly IBet _bet;
        private readonly ISpin _spin;
        public PayoutService(RouletteGameContext db, IMapper mapper, IBet bet, ISpin spin)
         : base(db)
        {
            _db = db;
            _mapper = mapper;
            _bet = bet;
            _spin = spin;   
        }
        public async Task<IEnumerable<PayoutDto>> GetAllPayoutsAsync()
        {
            var result = await GetAllAsync();
            if (result.Count == 0) return null;
            var payoutsDto = _mapper.Map<IEnumerable<PayoutDto>>(result);
            return payoutsDto;
        }
        public async Task<IEnumerable<PayoutDto>> GetAllPayoutsBySpinBetAsync(int spinId, int betId)
        {
            var result = await GetAllAsync();
            var payouts = new List<Payout>();
            foreach (var p in result)
            { 
                if(p.SpinId == spinId && p.BetId == betId)
                    payouts.Add(p);
            }
            var payoutsDto = _mapper.Map<IEnumerable<PayoutDto>>(payouts);
            return payoutsDto;
        }

        public async Task<PayoutDto> GetPayoutAsync(int Id, int spinId, int betId)
        {
            var bet = _bet.GetBet(betId);
            if (bet is null) return null;

            var result = await GetAllAsync(i => i.Id == Id && i.SpinId == spinId && i.BetId == betId);
            if (result != null) return null;
            var payout = result.Find(i => i.Id == Id && i.SpinId == spinId && i.BetId == betId);
            if (payout != null) return null;

            var payoutDto = _mapper.Map<PayoutDto>(payout);
            return payoutDto;
        }
        public async Task<PayoutDto> CreatePayout(int betId, int spinId, decimal amount)
        {
            var payout = new Payout();
            var spin = _spin.GetSpinAsync(spinId);
            if (spin is null) return null;

            Random random = new Random();
            int i = random.Next();
            Create(payout = new Payout()
            {
                Id = i,
                PayoutDate = DateTime.UtcNow,
                TotalPayoutAmount = amount,
                SpinId = spinId,
                BetId = betId,
            });
            var myPayout = _mapper.Map<Payout>(payout);
            using (_db)
            {
                var add = await AddAsync(myPayout);
            }
            var payoutDto = _mapper.Map<PayoutDto>(payout);
            return payoutDto;
        }
    }
}
