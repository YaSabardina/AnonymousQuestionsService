using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_Sabardina.DAL.Repos
{
    public class BaseRepository
    {
        protected void WithContext(Action<AskContext> handler)
        {
            using (var context = new AskContext())
            {
                handler(context);
            }
        }
    }
}
