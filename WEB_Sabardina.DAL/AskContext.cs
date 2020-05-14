using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Sabardina.DAL.Models;

namespace WEB_Sabardina.DAL
{
    public class AskContext : DbContext
    {
        public AskContext(): base(@"Data Source=DESKTOP-0T525FD\SQLEXPRESS;Initial Catalog=WEB_Sabardina;Integrated Security=True;MultipleActiveResultSets=True")
        {
        }
        public DbSet<Ask> Asks { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
