using System;

namespace BrokenShoeLeague.Data.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected LigaDelTenisRotoContext Context { get; set; }

        public void Dispose()
        {
            Context.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Dispose();
        }
    }
}
