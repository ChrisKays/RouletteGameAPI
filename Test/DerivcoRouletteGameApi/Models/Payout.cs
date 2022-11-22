using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.Models
{
    public class Payout
    {
        [Column("PayoutId")]
        public int Id { get; set; }
        public DateTime PayoutDate { get; set; }
        public decimal TotalPayoutAmount { get; set; }

        [ForeignKey(nameof(Spin))]
        public Nullable<int> SpinId { get; set; }
        public Spin? Spin { get; set; }

        [ForeignKey(nameof(Bet))]
        public Nullable<int> BetId { get; set; }
        public BetInfo? Bet { get; set; }

    }
}
