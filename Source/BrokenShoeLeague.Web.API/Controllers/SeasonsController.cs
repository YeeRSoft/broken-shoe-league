using System.Data.Entity.Infrastructure;
using System.Web.Http;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Domain.Repositories;

namespace BrokenShoeLeague.Web.API.Controllers
{
    public class SeasonsController : ApiController
    {
        private readonly IBrokenShoeLeagueRepository _brokenShoeLeagueRepository;

        public SeasonsController(IBrokenShoeLeagueRepository brokenShoeLeagueRepository)
        {
            _brokenShoeLeagueRepository = brokenShoeLeagueRepository;
        }

        // GET api/seasons
        public IHttpActionResult GetSeasons()
        {
            return Ok(_brokenShoeLeagueRepository.GetAllSeasons());
        }

        // GET api/players/5
        public IHttpActionResult GetSeason(int id)
        {
            var season = _brokenShoeLeagueRepository.GetSeasonById(id);
            if (season == null)
            {
                return NotFound();
            }
            return Ok(season);
        }

        // POST api/players
        public IHttpActionResult Post(Season season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _brokenShoeLeagueRepository.CreateSeason(season);
            _brokenShoeLeagueRepository.SaveChanges();
            return Ok(season);
        }

        // PUT api/players/5
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

        // DELETE api/players/5
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
    }
}
