using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.Models
{
    public class Spin
    {
        [Column("SpinId")]
        public int Id { get; set; }
        public long? Result { get; set; }
        public DateTime SpinDate { get; set; }

        [ForeignKey(nameof(BetInfo))]
        public Nullable<int> BetId { get; set; }
        public ICollection<BetInfo>? Bets { get; set; }
    }
}
