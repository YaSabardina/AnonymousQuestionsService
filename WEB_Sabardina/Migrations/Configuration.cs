using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using WEB_Sabardina.Infrastructure;
using WEB_Sabardina.Models;

namespace WEB_Sabardina.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<WEB_Sabardina.Infrastructure.AppIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WEB_Sabardina.Infrastructure.AppIdentityDbContext";
        }

        protected override async void Seed(WEB_Sabardina.Infrastructure.AppIdentityDbContext context)
        {
         
        }
    }
}
