using System;

namespace RouletteGameApi.DataObjects
{
    public class SpinDto
    {
        public int Id { get; set; }
        public long Result { get; set; }
        public DateTime SpinDate { get; set; }
        public int betId { get; set; }
    }
}
