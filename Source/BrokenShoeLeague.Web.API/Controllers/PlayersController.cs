using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Domain.Repositories;

namespace BrokenShoeLeague.Web.API.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IBrokenShoeLeagueContext _brokenShoeLeagueContext;

        public PlayersController()
        {
            _brokenShoeLeagueContext = (IBrokenShoeLeagueContext) GlobalConfiguration.Configuration.
                DependencyResolver.GetService(typeof (IBrokenShoeLeagueContext));
        }

        // GET api/players
        public IHttpActionResult GetPlayers()
        {
            return Ok(_brokenShoeLeagueContext.GetAllPlayers());
        }

        // GET api/players/5
        public IHttpActionResult GetPlayer(int id)
        {
            var player = _brokenShoeLeagueContext.GetPlayerById(id);
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

            _brokenShoeLeagueContext.InsertPlayer(p);
            _brokenShoeLeagueContext.SaveChanges();
            return Ok(p);
        }

        // PUT api/players/5
        public IHttpActionResult Put([FromUri]int id, [FromBody]Player player)
        {
            var currentPlayer = _brokenShoeLeagueContext.GetPlayerById(id);
            if (ModelState.IsValid && currentPlayer != null)
            {
                try
                {
                    player.Id = id;
                    _brokenShoeLeagueContext.UpdatePlayer(player);
                    _brokenShoeLeagueContext.SaveChanges();
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
            var player = _brokenShoeLeagueContext.GetPlayerById(id);
            if (player == null)
                return NotFound();
            _brokenShoeLeagueContext.RemovePlayer(player);
            try
            {
                _brokenShoeLeagueContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok(player);
        }
    }
}
