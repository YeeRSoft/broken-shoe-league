using System.Data.Entity.Infrastructure;
using System.Web.Http;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Domain.Repositories;

namespace BrokenShoeLeague.Web.API.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IBrokenShoeLeagueRepository _brokenShoeLeagueRepository;

        public PlayersController(IBrokenShoeLeagueRepository brokenShoeLeagueRepository)
        {
            _brokenShoeLeagueRepository = brokenShoeLeagueRepository;
        }

        // GET api/players
        public IHttpActionResult GetPlayers()
        {
            return Ok(_brokenShoeLeagueRepository.GetAllPlayers());
        }

        // GET api/players/5
        public IHttpActionResult GetPlayer(int id)
        {
            var player = _brokenShoeLeagueRepository.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST api/players
        public IHttpActionResult Post(Player p)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _brokenShoeLeagueRepository.CreatePlayer(p);
            _brokenShoeLeagueRepository.SaveChanges();
            return Ok(p);
        }

        // PUT api/players/5
        public IHttpActionResult Put([FromUri]int id, [FromBody]Player player)
        {
            var currentPlayer = _brokenShoeLeagueRepository.GetPlayerById(id);
            if (ModelState.IsValid && currentPlayer != null)
            {
                try
                {
                    player.Id = id;
                    _brokenShoeLeagueRepository.UpdatePlayer(player);
                    _brokenShoeLeagueRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return Ok(player);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/players/5
        public IHttpActionResult Delete(int id)
        {
            var player = _brokenShoeLeagueRepository.GetPlayerById(id);
            if (player == null)
                return NotFound();
            _brokenShoeLeagueRepository.RemovePlayer(player);
            try
            {
                _brokenShoeLeagueRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok(player);
        }
    }
}
