using RouletteGameApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RouletteGameApi.Controllers
{
    [ApiController]
    [Route("api/Payout")]
    public class PayoutController : ControllerBase
    {
        private readonly IPayout _payout;
        public PayoutController(IPayout payout)
        {
            _payout = payout;
        }

        [HttpGet("GetPayouts")]
        public async Task<IActionResult> GetPayouts()
        {
            var payouts = await _payout.GetAllPayoutsAsync();
            if (payouts == null)
                return BadRequest("No existing payouts found.");

            return Ok(payouts);
        }
        [HttpGet("GetPayoutsBySpinBet")]
        public async Task<IActionResult> GetPayoutsBySpinBet(int spinId, int betId)
        {
            var payouts = await _payout.GetAllPayoutsBySpinBetAsync(spinId, betId);

            return Ok(payouts);
        }
    }
}
