using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RouletteGameApi.Models
{
    public class BetInfo
    {
        [Column("BetId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "BetChoice cannot be empty")]
        public int BetChoice { get; set; }

        public DateTime BetDate { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive amount.")]
        public decimal BetAmount { get; set; }
        //public Spin? Spin { get; set; }
        //public Payout? Payout { get; set; }
    }
}
