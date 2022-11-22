using System;

namespace RouletteGameApi.DataObjects
{
    public class BetDto
    {
        public int Id { get; set; }
        public string BetChoice { get; set; }
        public DateTime BetDate { get; set; }
        public decimal BetAmount { get; set; }
    }
}
