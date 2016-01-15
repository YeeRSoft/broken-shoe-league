using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrokenShoeLeague.Domain.Repositories;
using BrokenShoeLeague.Services.Achievement;

namespace BrokenShoeLeague.Web.API.Controllers
{
    [RoutePrefix("api/v1/achievements")]
    public class AchievementsController : ApiController
    {
        private readonly IBrokenShoeLeagueRepository _brokenShoeLeagueRepository;
        private readonly IAchivementProviderService _achivementProviderService;

        public AchievementsController(IBrokenShoeLeagueRepository brokenShoeLeagueRepository, IAchivementProviderService achivementProviderService)
        {
            _brokenShoeLeagueRepository = brokenShoeLeagueRepository;
            _achivementProviderService = achivementProviderService;
        }

        [Route("")]
        public IHttpActionResult GetAchievements()
        {
            return Ok(_achivementProviderService.GetAchievements());
        }
    }
}
