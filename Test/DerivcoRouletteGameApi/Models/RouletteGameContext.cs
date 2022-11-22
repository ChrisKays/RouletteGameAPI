using Microsoft.EntityFrameworkCore;

namespace RouletteGameApi.Models
{
    public class RouletteGameContext : DbContext
    {
        public RouletteGameContext()
        {
        }

        public RouletteGameContext(DbContextOptions<RouletteGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BetInfo> BetInfos { get; set; }
        public virtual DbSet<Spin> Spins { get; set; }
        public virtual DbSet<Payout> Payouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=C:\Users\user\Documents\Derivco\ASSESSMENT\Test\DerivcoRouletteGameApi\DerivcoRouletteGame.db");
    }
}
