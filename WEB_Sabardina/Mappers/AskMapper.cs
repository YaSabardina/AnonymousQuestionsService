using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_Sabardina.DAL.Models;
using WEB_Sabardina.Models;

namespace WEB_Sabardina.Mappers
{
    public static class AskMapper
    {
        public static AskViewModel ToView(this Ask model) =>
           new AskViewModel
           {
               Id = model.Id,
               Question = model.Question,
               Answer = model.Answer,
               UserId = model.UserId,
              // User = model.User?.ToView()
           };


        public static Ask ToEntity(this AskViewModel model) =>
            new Ask
            {
                Id = model.Id,
                Question = model.Question,
                Answer = model.Answer,
                UserId = model.UserId,

                User = model.User?.ToEntity()
            };
        
        public static IEnumerable<Ask> ToEntity(this IEnumerable<AskViewModel> model) =>
            model.Select(x => x.ToEntity());
        public static IEnumerable<AskViewModel> ToView(this IEnumerable<Ask> model) =>
            model.Select(x => x.ToView());
    }
}