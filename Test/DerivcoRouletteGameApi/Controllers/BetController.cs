using AutoMapper;
using RouletteGameApi.DataObjects;
using RouletteGameApi.Models;
using RouletteGameApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteGameApi.Controllers
{
    [ApiController]
    [Route("api/Bets")]
    public class BetController : ControllerBase
    {
        private readonly IBet _bet; 
        private readonly IMapper _mapper;
        public BetController(IBet bet, IMapper mapper)
        {
            _bet = bet;
            _mapper = mapper;   
        }
        [HttpGet("GetBet")]
        public async Task<IActionResult> GetBet(int betId)
        {
            var bet = await _bet.GetBet(betId);
            if (bet == null)
                return BadRequest("Bet not found");

            return Ok(bet);
        }

        [HttpGet("BetCollection")]
        public async Task<IActionResult> GetBets()
        {
            var bets = await _bet.GetBetCol();
            if (bets == null)
                return BadRequest("No existing bets found.");

            return Ok(bets);
        }
        [HttpPost("PlaceBet")]
        public async Task<IActionResult> PlaceBet([FromBody] BetInfo bet)
        {
            var newBet = await _bet.PlaceBetAsync(bet);

            return Ok(newBet);
        }
    }
}
