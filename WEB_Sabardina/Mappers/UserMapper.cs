using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_Sabardina.DAL.Models;
using WEB_Sabardina.Models;

namespace WEB_Sabardina.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToView(this User model) =>
            new UserViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                Email = model.Email
            };


        public static User ToEntity(this UserViewModel model) =>
            new User
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                Email = model.Email
            };
        public static UserViewModel ToView(this AppUser model) =>
            new UserViewModel
            {
                Name = model.UserName,
                Email = model.Email
            };
        public static User ToEntity(this AppUser model) =>
            new User
            {
                Name = model.UserName,
                Email = model.Email
            };
        public static IEnumerable<User> ToEntity(this IEnumerable<UserViewModel> model) =>
            model.Select(x => x.ToEntity());
        public static IEnumerable<UserViewModel> ToView(this IEnumerable<User> model) =>
            model.Select(x => x.ToView());
    }
}