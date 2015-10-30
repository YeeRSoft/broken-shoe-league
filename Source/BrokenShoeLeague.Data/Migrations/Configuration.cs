using System.Web.Security;
using BrokenShoeLeague.Domain;
using WebMatrix.WebData;

namespace BrokenShoeLeague.Data.Migrations
{
    using System;
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
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }

            #region Users & Roles

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!Roles.RoleExists("Guest"))
                Roles.CreateRole("Guest");

            if (!Roles.RoleExists("StatsEditor"))
                Roles.CreateRole("StatsEditor");

            if (!WebSecurity.UserExists("admin"))
            {
                WebSecurity.CreateUserAndAccount("admin", "HalaMadrid", new { Email = "yoliva0201@gmail.com", Role = "Administrator", ConfirmationLink = true, NotificationsByEmail = true });
            }

            if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
            {
                Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
            }
            #endregion

            context.MatchDays.Add(new MatchDay()
            {
                Date = DateTime.Now,
                Number = 1
            });
            context.SaveChanges();
        }
    }
}
