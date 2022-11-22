using RouletteGameApi.Models;
using System;

namespace RouletteGameApi.DataObjects
{
    public class PayoutDto
    {
        public int Id { get; set; }
        public DateTime PayoutDate { get; set; }
        public decimal TotalPayoutAmount { get; set; }
        public int SpinId { get; set; }
        public int BetId { get; set; }
    }
}
