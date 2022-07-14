using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVC_User.DAL;
using MVC_User.Models;

namespace MVC_User.Controllers
{
    public class UserController : Controller
    {
        User_DAL _userDal = new User_DAL();
        /*********for get list of users**************/
        public ActionResult ShowAllUser()
        { 
            ViewBag.Message = "test page.";
            var list_of_users = _userDal.Show_all_users();
            return View(list_of_users);
        }
        /*********for add new user**************/
        public ActionResult Add_User_wm()//with model
        {
            User oUsers = new User();
            return View(oUsers);
        }
        public ActionResult Add_User()
        {
            List<User> oUsers = new List<User>();
            return View(oUsers);
        }
        [HttpPost]
        public JsonResult Save_User(User oUser)
        {
            oUser.Save_User(oUser);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(oUser);
            return Json(json, JsonRequestBehavior.AllowGet);
        } 
    }
}
