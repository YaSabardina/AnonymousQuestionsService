using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_Sabardina.DAL.Models;
using WEB_Sabardina.DAL.Repos;
using WEB_Sabardina.Infrastructure;
using WEB_Sabardina.Mappers;
using WEB_Sabardina.Models;

namespace WEB_Sabardina.Controllers
{
    public class AskController : Controller
    {
        AskRepository askRepository = new AskRepository();
        UserRepository userRepository = new UserRepository();
        [Authorize]
        public ActionResult Index()
        {
            return Redirect("/Ask/DetailsUser/"+userRepository.GetUser(GetAutoUser().UserName).Id);

        }
        [Authorize]
        public ActionResult MyMessages()
        {
            return View(askRepository.GetAsks().Where(x => x.User.Name == GetAutoUser().UserName).ToView());
        }
        public ActionResult CreateQuestion(int id)
        {
            var ask = new AskViewModel {UserId=id };
            return View(ask);
        }
        [HttpPost]
        public ActionResult CreateQuestion(AskViewModel model)
        {
            var ask = model.ToEntity();
            askRepository.Create(ask);
            return View();
        }
        public ActionResult CreateAnswer(int id)
        {
            var ask = askRepository.GetAsk(id);
            return View(ask.ToView());
        }
        [HttpPost]
        public ActionResult CreateAnswer(AskViewModel model)
        {
            var ask = askRepository.GetAsk(model.Id);
            ask.Answer = model.Answer;
            askRepository.Update(ask);
            return Redirect("/Home/Index");
        }
        public ActionResult DetailsUser(int id)
        {
            var user = new ProfUserViewModel
            {
                User = userRepository.GetUser(id).ToView(),
                Asks = askRepository.GetAsks().Where(x => x.UserId == id).ToView().ToList()
            };
            return View(user);
        }
        public ActionResult GetUsers()
        {
            return View(userRepository.GetUsers().ToView());
        }

        public AppUser GetAutoUser() =>
             UserManager.Users.First(x => x.UserName == HttpContext.User.Identity.Name);

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}