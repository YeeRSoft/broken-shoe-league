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
            var responseContent = _brokenShoeLeagueRepository.GetAllSeasons()
                .Select(x => new
                {
                    x.Id,
                    x.Name
                });
            return Ok(responseContent);
        }

        [Route("{id}")]
        public IHttpActionResult GetSeason(int id)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(id);

            if (season == null)
                return NotFound();

            var response = new SeasonViewModel(season);

            return Ok(response);
        }

        public IHttpActionResult Post([FromBody]Season season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _brokenShoeLeagueRepository.CreateSeason(season);
            _brokenShoeLeagueRepository.SaveChanges();
            return Ok(season);
        }

        public IHttpActionResult Put([FromUri]int id, [FromBody]Season season)
        {
            var currentPlayer = _brokenShoeLeagueRepository.GetPlayerById(id);
            if (ModelState.IsValid && currentPlayer != null)
            {
                try
                {
                    season.Id = id;
                    _brokenShoeLeagueRepository.UpdateSeason(season);
                    _brokenShoeLeagueRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return Ok(season);
            }
            else
            {
                return BadRequest(ModelState);
            }
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
            return Ok(season);
        }

        [Route("matchdays/{seasonId}")]
        public IHttpActionResult GetSeasonMatchdays(int seasonId)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(seasonId);
            if (season == null)
                return NotFound();

            return Ok(season.Matchdays);
        }

        [Route("ranking/{seasonId}")]
        public IHttpActionResult GetSeasonRanking(int seasonId)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(seasonId);
            if (season == null)
                return NotFound();

            return Ok();
        }

        [Route("topScorers/{seasonId}")]
        public IHttpActionResult GetSeasonTopScorers(int seasonId)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(seasonId);
            if (season == null)
                return NotFound();

            return Ok(_seasonStatsProvider.GetSeasonTopScorers(seasonId));
        }

        [Route("topAssits/{seasonId}")]
        public IHttpActionResult GetSeasonTopAssits(int seasonId)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(seasonId);
            if (season == null)
                return NotFound();

            return Ok(_seasonStatsProvider.GetSeasonTopAssists(seasonId));
        }
    }
}
