using MVCDapper.Models;
using MVCDapperKutuphane.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Dapper;
using Microsoft.SqlServer.Server;

namespace MVCDapperKutuphane.Controllers
{
    [AllowAnonymous]
    public class AccountsController : Controller
    {

        public ActionResult Login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(User user)
        {
            IEnumerable<UserMaster> userList;
            using (SqlConnection baglanti = new SqlConnection(DP.connectionString))
            {
                baglanti.Open();
                userList = baglanti.Query<UserMaster>("SELECT*FROM UserMaster where Name1=@Username and Password1=@Password1", user);
            }
            if (userList.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "hatalı kullanıcı adı ya da şifre";
            }
            return View();
        }
        // GET: Accounts
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(User user)
        //{
        //    IEnumerable<UserMaster> userList;
        //    using (SqlConnection baglanti = new SqlConnection(DP.connectionString))
        //    {
        //        baglanti.Open();
        //        userList = baglanti.Query<UserMaster>("SELECT*FROM UserMaster where Name1=@Username and Password1=@Password1", user);
        //    }
        //    if (userList.Count() > 0)
        //    {
        //        FormsAuthentication.SetAuthCookie(user.Username, false);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        TempData["msg"] = "hatalı kullanıcı adı ya da şifre";
        //    }
        //    return View();
        //}
        //using (kutuphaneEntities db = new kutuphaneEntities())
        //{
        //    var result = db.UserMasters.Where(x => x.Userld == user.Username && x.Password1 == user.Pasword1);
        //    if (result.Count() != 0)
        //    {
        //        FormsAuthentication.SetAuthCookie(user.Username, false);
        //        //Session["userId"]=user.Username;
        //        return RedirectToAction("Admin", "Admin");
        //    }
        //    else
        //    {
        //        TempData["msg"] = "hatalı";
        //    }
        //}
        //    return View();

        //}
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}