using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Sabardina.DAL.Models;

namespace WEB_Sabardina.DAL.Repos
{
    public class AskRepository:BaseRepository
    {
        UserRepository userRepository = new UserRepository();

        public void Create(Ask model)
        {
            WithContext(context =>
            {
                context.Asks.Add(model);
                context.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            WithContext(context =>
            {
                var ask = context.Asks.Single(x => x.Id.Equals(id));

                context.Asks.Remove(ask);

                context.SaveChanges();
            });
        }


        public void Update(Ask model)
        {
            WithContext(context =>
            {
                var user = context.Asks.Single(x => x.Id.Equals(model.Id));

                user.Id = model.Id;
                user.Answer = model.Answer;
                user.Question = model.Question;
                user.UserId = model.UserId;
                context.SaveChanges();
            });
        }
        public IEnumerable<Ask> GetAsks()
        {
            var result = new Ask[] { };

            WithContext(context =>
            {
                result = context.Asks.ToArray()
                .Select(x => new Ask
                {
                    Id = x.Id,
                    Answer = x.Answer,
                    Question = x.Question,
                    UserId=x.UserId,
                    User = userRepository.GetUser(x.User.Id),

                }).ToArray();
            });

            return result;
        }
        public Ask GetAsk(int id)
        {
            Ask ask = null;
            WithContext(context =>
            {
                ask = context.Asks.First(x => x.Id.Equals(id));
            });

            return ask;
        }
    }
}
