using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Domain.Repositories;
using BrokenShoeLeague.Services.Seasons;
using BrokenShoeLeague.Web.API.Models;

namespace BrokenShoeLeague.Web.API.Controllers
{
    [RoutePrefix("api/v1/seasons")]
    public class SeasonsController : ApiController
    {
        private readonly IBrokenShoeLeagueRepository _brokenShoeLeagueRepository;
        private readonly ISeasonStatsProvider _seasonStatsProvider;

        public SeasonsController(IBrokenShoeLeagueRepository brokenShoeLeagueRepository, ISeasonStatsProvider seasonStatsProvider)
        {
            _brokenShoeLeagueRepository = brokenShoeLeagueRepository;
            _seasonStatsProvider = seasonStatsProvider;
        }

        [Route("")]
        public IHttpActionResult GetSeasons()
        {
            var seasons = _brokenShoeLeagueRepository.GetAllSeasons().Select(x => new
            {
                x.Id,
                x.Name,
                x.StartDate,
                x.EndDate
            });
            return Ok(seasons);
        }

        [Route("{id}")]
        public IHttpActionResult GetSeason(int id)
        {
            if (!_brokenShoeLeagueRepository.SeasonExist(id))
                return NotFound();

            var response = new SeasonViewModel(_brokenShoeLeagueRepository.GetSeasonById(id));

            return Ok(response);
        }

        //create season
        public IHttpActionResult Post([FromBody]SeasonViewModel season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _brokenShoeLeagueRepository.CreateSeason(new Season
            {
                Name = season.Name,
                StartDate = season.StartDate
            });
            _brokenShoeLeagueRepository.SaveChanges();

            return Ok(season);
        }

        //update season
        public IHttpActionResult Put([FromUri]int id, [FromBody]SeasonViewModel season)
        {
            var currentSeason = _brokenShoeLeagueRepository.GetSeasonById(id);

            if (!ModelState.IsValid || currentSeason == null)
                return BadRequest(ModelState);
            try
            {
                currentSeason.Update(season.Name, season.StartDate, season.EndDate);
                _brokenShoeLeagueRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok(season);
        }

        public IHttpActionResult Delete(int id)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(id);
            if (season == null)
                return NotFound();
            _brokenShoeLeagueRepository.RemoveSeason(season);
            try
            {
                _brokenShoeLeagueRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok(new SeasonViewModel(season));
        }

        [Route("{seasonId}/matchdays")]
        public IHttpActionResult GetMatchdays(int seasonId)
        {
            if (!_brokenShoeLeagueRepository.SeasonExist(seasonId))
                return NotFound();

            var season = _brokenShoeLeagueRepository.GetSeasonById(seasonId);

            return Ok(season.Matchdays.Select(x => new MatchdayViewModel(x)));
        }

        [Route("{seasonId}/ranking")]
        public IHttpActionResult GetRanking(int seasonId)
        {
            if (_brokenShoeLeagueRepository.SeasonExist(seasonId))
                return NotFound();

            var ranking = _seasonStatsProvider.GetSeasonRanking(seasonId);

            return Ok(ranking);
        }

        [Route("{seasonId}/topScorers")]
        public IHttpActionResult GetTopScorers(int seasonId)
        {
            if (!_brokenShoeLeagueRepository.SeasonExist(seasonId))
                return NotFound();

            return Ok(_seasonStatsProvider.GetSeasonTopScorers(seasonId));
        }

        [Route("topAssits/{seasonId}")]
        public IHttpActionResult GetTopAssits(int seasonId)
        {
            if (!_brokenShoeLeagueRepository.SeasonExist(seasonId))
                return NotFound();

            return Ok(_seasonStatsProvider.GetSeasonTopAssists(seasonId));
        }
    }
}
