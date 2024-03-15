
namespace Bowling.Models
{
    public class EFBowlerRepository : IBowlerRepository
    { 
        private BowlingLeagueContext _context;

        public EFBowlerRepository(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        public List<Bowler> Bowlers => _context.Bowlers.ToList();
        public List<Team> Teams => _context.Teams.ToList();
    }
}
