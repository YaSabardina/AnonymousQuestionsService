using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Sabardina.DAL.Models;

namespace WEB_Sabardina.DAL.Repos
{
    public class UserRepository:BaseRepository
    {
        public void Create(User model)
        {
            WithContext(context =>
            {
                context.Users.Add(model);
                context.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(id));

                context.Users.Remove(user);

                context.SaveChanges();
            });
        }


        public void Update(User model)
        {
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(model.Id));

                user.Id = model.Id;
                user.Name = model.Name;
                user.Password = model.Password;
                user.Email = model.Email;
                context.SaveChanges();
            });
        }
        public IEnumerable<User> GetUsers()
        {
            var result = new User[] { };

            WithContext(context =>
            {
                result = context.Users.ToArray()
                .Select(x => new User
                {
                    Id = x.Id,
                    Name = x.Name,
                    Password = x.Password,
                    Email = x.Email,

                }).ToArray();
            });

            return result;
        }
        public User GetUser(string name)
        {
            User user = null;
            WithContext(context =>
            {
                user = context.Users.First(x => x.Name.Equals(name));
            });

            return user;
        }
        public User GetUser(int id)
        {
            User user = null;
            WithContext(context =>
            {
                user = context.Users.First(x => x.Id.Equals(id));
            });

            return user;
        }
    }
}
