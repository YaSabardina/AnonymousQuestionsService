namespace WEB_Sabardina.DAL.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using WEB_Sabardina.DAL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WEB_Sabardina.DAL.AskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WEB_Sabardina.DAL.AskContext context)
        {
            context.Users.AddRange(new List<User> {
              new User { Name = "Andrew Peters",Email="Andrew@gmail.com" },
              new User { Name = "Brice Lambson", Email = "Lambson@gmail.com" },
              new User { Name = "Rowan Miller", Email = "Miller@gmail.com" }
            });

        }
    }
}
