using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrokenShoeLeague.Domain;
using BrokenShoeLeague.Domain.Repositories;

namespace BrokenShoeLeague.Web.API.Controllers
{
    public class SeasonsController : ApiController
    {
                private readonly IBrokenShoeLeagueContext _brokenShoeLeagueContext;

        public SeasonsController()
        {
            _brokenShoeLeagueContext = (IBrokenShoeLeagueContext) GlobalConfiguration.Configuration.
                DependencyResolver.GetService(typeof (IBrokenShoeLeagueContext));
        }

        // GET api/seasons
        public IHttpActionResult GetSeasons()
        {
            return Ok(_brokenShoeLeagueContext.GetAllSeasons());
        }

        // GET api/players/5
        public IHttpActionResult GetSeason(int id)
        {
            var season = _brokenShoeLeagueContext.GetSeasonById(id);
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

            _brokenShoeLeagueContext.CreateSeason(season);
            _brokenShoeLeagueContext.SaveChanges();
            return Ok(season);
        }

        // PUT api/players/5
        public IHttpActionResult Put([FromUri]int id, [FromBody]Season season)
        {
            var currentPlayer = _brokenShoeLeagueContext.GetPlayerById(id);
            if (ModelState.IsValid && currentPlayer != null)
            {
                try
                {
                    season.Id = id;
                    _brokenShoeLeagueContext.UpdateSeason(season);
                    _brokenShoeLeagueContext.SaveChanges();
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
            var season = _brokenShoeLeagueContext.GetSeasonById(id);
            if (season == null)
                return NotFound();
            _brokenShoeLeagueContext.RemoveSeason(season);
            try
            {
                _brokenShoeLeagueContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok(season);
        }
    }
}
