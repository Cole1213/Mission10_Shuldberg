namespace Bowling.Models
{
    public interface IBowlerRepository
    {
        List<Bowler> Bowlers { get; }
        List<Team> Teams { get; }
    }
}
