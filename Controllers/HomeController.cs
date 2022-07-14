using MVC_User.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_User.Controllers
{
    public class HomeController : Controller
    {
        User_DAL _userDal = new User_DAL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Test()
        {
            var list_of_users = _userDal.Show_all_users();
            return View(list_of_users);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}