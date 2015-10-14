using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using BrokenShoeLeague.Data;
using BrokenShoeLeague.Domain.Repositories;

namespace BrokenShoeLeague.Web.API
{
    public class CustomResolver : IDependencyResolver, IDependencyScope
    {
        public void Dispose()
        {
            //do nothing
        }

        public object GetService(Type serviceType)
        {
            return serviceType == typeof (IBrokenShoeLeagueContext)
                ? new BrokenShoeLeagueContext()
                : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}