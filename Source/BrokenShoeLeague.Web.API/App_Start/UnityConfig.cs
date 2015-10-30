using BrokenShoeLeague.Data;
using BrokenShoeLeague.Domain.Repositories;
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
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IBrokenShoeLeagueRepository, BrokenShoeLeagueContext>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}