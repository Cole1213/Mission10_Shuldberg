using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace Bowling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlerController
    {
        private IBowlerRepository _repo;

        public BowlerController(IBowlerRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var joinedData = from bowler in _repo.Bowlers
                             join team in _repo.Teams
                             on bowler.TeamId equals team.TeamId
                             where team.TeamName == "Marlins" || team.TeamName == "Sharks"
                             select new
                             {
                                 BowlerId = bowler.BowlerId,
                                 BowlerFirstName = bowler.BowlerFirstName,
                                 BowlerLastName = bowler.BowlerLastName,
                                 BowlerMiddleInit = bowler.BowlerMiddleInit,
                                 TeamName = team.TeamName,
                                 BowlerAddress = bowler.BowlerAddress,
                                 BowlerCity = bowler.BowlerCity,
                                 BowlerState = bowler.BowlerState,
                                 BowlerZip = bowler.BowlerZip,
                                 BowlerPhoneNumber = bowler.BowlerPhoneNumber
                             };

            return joinedData.ToList();
        }
    }
}
