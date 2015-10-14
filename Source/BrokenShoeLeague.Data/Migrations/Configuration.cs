using BrokenShoeLeague.Domain;

namespace BrokenShoeLeague.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrokenShoeLeagueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BrokenShoeLeagueContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Players.AddOrUpdate(
              p => p.Name,
              new Player { Name = "Player1", Enabled = true},
              new Player { Name = "Player2", Enabled = true},
              new Player { Name = "Player3", Enabled = true}
            );
            //
        }
    }
}
