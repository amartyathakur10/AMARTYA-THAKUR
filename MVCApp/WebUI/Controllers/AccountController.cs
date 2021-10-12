using DAL.Repositories;
using DomainModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        IUnitOfWork uow;
        public AccountController(IUnitOfWork _uow)
        {
            //uow = new UnitOfWork();

            uow = _uow;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            UserModel user = uow.AuthRepo.ValidateUser(model.Username, model.Password);
            if (user != null)
            {
                string data = JsonConvert.SerializeObject(user);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, data);
                string encTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(authCookie);

                if (user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else if (user.Roles.Contains("User"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "User" });
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}