using AutoMapper;
using RouletteGameApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RouletteGameApi.Controllers
{
    [ApiController]
    [Route("api/Spins")]
    public class SpinController : ControllerBase
    {
        private readonly ISpin _spin;
        private readonly IBet _bet;
        private readonly IPayout _payout;
        public SpinController(ISpin spin, IBet bet, IPayout payout)
        {
            _spin = spin;
            _bet = bet;
            _payout = payout;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpins()
        {
            var spins = await _spin.GetAllSpinsAsync();
            if (spins == null)
                return BadRequest("No existing spins found.");
            return Ok(spins);
        }

        [HttpGet("bets/{betId}/DoSpin")]
        public async Task<IActionResult> DoSpin(int betId)
        {
            var bet = await _bet.GetBet(betId);
            if (bet == null)
                return BadRequest("Bet not found, please place a bet first");

            var spin = await _spin.DoSpinAsync(bet, _payout);

            return Ok(spin);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetSpin(int spinId)
        {
            var spin = await _spin.GetSpinAsync(spinId);
            if (spin == null)
                return BadRequest("Spin not found");

             return Ok(spin);
        }
    }
}
