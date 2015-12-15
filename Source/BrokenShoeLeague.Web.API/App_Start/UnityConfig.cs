using BrokenShoeLeague.Data;
using BrokenShoeLeague.Domain.Repositories;
using BrokenShoeLeague.Services.Seasons;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace BrokenShoeLeague.Web.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IBrokenShoeLeagueRepository, BrokenShoeLeagueContext>();
            container.RegisterType<ISeasonStatsProvider, SeasonStatsProvider>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}