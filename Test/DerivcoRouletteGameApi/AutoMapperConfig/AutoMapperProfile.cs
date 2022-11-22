using AutoMapper;
using RouletteGameApi.DataObjects;
using RouletteGameApi.Models;

namespace RouletteGameApi.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
		public AutoMapperProfile()
		{
			CreateMap<BetInfo, BetDto>();
			CreateMap<Spin, SpinDto>();
			CreateMap<Payout, PayoutDto>();
		}
	}
}
