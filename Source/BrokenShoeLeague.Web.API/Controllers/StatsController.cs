using System.Linq;
using System.Web.Http;
using BrokenShoeLeague.Domain.Repositories;

namespace BrokenShoeLeague.Web.API.Controllers
{
    public class StatsController : ApiController
    {
        private readonly IBrokenShoeLeagueRepository _brokenShoeLeagueRepository;

        public StatsController(IBrokenShoeLeagueRepository brokenShoeLeagueRepository)
        {
            _brokenShoeLeagueRepository = brokenShoeLeagueRepository;
        }

        public IHttpActionResult GetRanking(int seasonId)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(seasonId);

            if (season == null)
                return NotFound();

            var seasonPlayers= _brokenShoeLeagueRepository.GetAllPlayers()
                .Where(p => p.PlayerRecords.Any(pr => pr.Matchday.Season.Id == seasonId));

            return Ok();
        }
    }
}
