using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tourTravels.Models;

namespace tourTravels.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DBManager db=new DBManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult viewbooking() 
        {

            return View();
        }
        public ActionResult Deletebooking(string del)
        {
            string cmd = "delete from booking where bid='" + del + "'";
            if (db.myinsertupdatedelete(cmd))
            {
                Response.Write("<script>alert('Data Deleted');window.location.href='/manager/viewbooking';</script>");
            }
            else
            {
                Response.Write("<script>alert('Data not Deleted');window.location.href='/manager/viewbooking';</script>");
            }
            return View();
        }
        public ActionResult viewlogin()
        {

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("/home/index");
            return View();
        }
    }
}