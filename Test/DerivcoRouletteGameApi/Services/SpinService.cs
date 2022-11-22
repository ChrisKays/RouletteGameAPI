using AutoMapper;
using RouletteGameApi.DataObjects;
using RouletteGameApi.Models;
using RouletteGameApi.Repositories;
using RouletteGameApi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Services
{
    public class SpinService : Repository<Spin>, ISpin
    {
        private readonly RouletteGameContext _db;
        private readonly IMapper _mapper;
        private readonly Dictionary<int, decimal> _payoutLookUp = new Dictionary<int, decimal>();
        public SpinService(RouletteGameContext db, IMapper mapper)
         : base(db)
        {
            _db = db;
            _mapper = mapper;
            for (int x = 1; x <= 100; x++)
            {
                var rand = new Random();
                var value = new decimal(rand.NextDouble());
                decimal amount = Math.Round(value, 2);
                _payoutLookUp.TryAdd(x, amount * 1000);
            }
        }

        public async Task<IEnumerable<SpinDto>> GetAllSpinsAsync()
        {
            var result = await GetAllAsync();
            if (result.Count == 0) return null;
            var spinsDto = _mapper.Map<IEnumerable<SpinDto>>(result);
            return spinsDto;
        }

        public async Task<SpinDto> DoSpinAsync(BetInfo bet, IPayout payout)
        {
            var spin = new Spin();
            var spins = new List<Spin>();
            var nextSpin = await GetAllAsync();
            //nextSpin.ForEach(x => (!x.Result.HasValue)spins.Add(x));

            Random random1 = new Random();
            Random random = new Random();
            int i = random.Next();
            int x = random1.Next(1, 100);
            Create(spin = new Spin()
            {
                Id = i,
                Result = x,
                SpinDate = DateTime.UtcNow,
                BetId = bet.Id,
            });

            var mySpin = _mapper.Map<Spin>(spin);
            using (_db)
            {
                //_db.Add(spin);
                //await _db.SaveChangesAsync();
                var add = await AddAsync(mySpin);

                #region Payout
                if (bet.BetChoice == mySpin.Result)
                {
                    _payoutLookUp.TryGetValue((int)mySpin.Result, out var pay);
                    await payout.CreatePayout(bet.Id, mySpin.Id, pay);
                } else
                    await payout.CreatePayout(bet.Id, mySpin.Id, 0);
                #endregion
            }
            var spinDto = _mapper.Map<SpinDto>(spin);

            return spinDto;
        }

        public async Task<SpinDto> GetSpinAsync(int spinId)
        {
            var result = await GetAllAsync(i => i.Id == spinId);
            var spin = result.Find(i => i.Id == spinId);
            if (spin is null) return null;

            var spinDto = _mapper.Map<SpinDto>(spin);

            return spinDto;
        }
    }
}
