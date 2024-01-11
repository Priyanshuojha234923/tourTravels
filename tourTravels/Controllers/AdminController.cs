using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tourTravels.Models;

namespace tourTravels.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        encpassword epass=new encpassword();
        DBManager db=new DBManager();
        public ActionResult Index()
        {
            if (Session["aid"]==null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult viewbooking()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }

            return View();
        }
        public ActionResult Deletebooking(string del)
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else { 
            string cmd = "delete from booking where bid='" + del + "'";
            if (db.myinsertupdatedelete(cmd))
            {
                Response.Write("<script>alert('Data Deleted');window.location.href='/manager/viewbooking';</script>");
            }
            else
            {
                Response.Write("<script>alert('Data not Deleted');window.location.href='/manager/viewbooking';</script>");
            }
            }
            return View();
        }
        public ActionResult viewlogin()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }

            return View();
        }
        public ActionResult Logout()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {

            
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("/home/index");
            }
            return View();
        }
        public ActionResult viewcontact()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult viewRegistration()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult viewplace()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");
             
            }
         
            return View();
            
        }
        public ActionResult dplace(string id)
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
                string cmd = "delete from tbl_place where pid='" + id + "'";
                if (db.myinsertupdatedelete(cmd))
                {
                    Response.Write("<script>alert('Data Deleted');window.location.href='/Admin/Viewplace';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data Not Deleted');window.location.href='/Admin/Viewplace';</script>");

                }
            }
            return View();
        }
        public ActionResult cpassword()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        [HttpPost]
        public ActionResult cpassword(string opass, string cnpass, string npass)
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else { 
            if (npass == cnpass)
            {
                    string lpass = epass.Encryption(npass);
                string cmd = "update tbl_login set password='" + lpass + "' where userid='" + Session["aid"].ToString() +"' ";
                if (db.myinsertupdatedelete(cmd))
                {
                    ViewBag.msg = "Password Updated";
                }
                else
                {
                    ViewBag.msg = "Error";
                }
            }
            else
            {
                ViewBag.msg = "New Password and confirm Password Not Matched";
            }
            }
            return View();
        }
        public ActionResult vhbooking()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult viewhotel()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult dhotel( string del)
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else { 
            string cmd = "delete from tbl_hotel  where id='" + del + "'";
            if (db.myinsertupdatedelete(cmd))
            {
                Response.Write("<script>alert('Data Deleted');window.location.href='/admin/Viewhotel';</script>");
            }
            else
            {
                Response.Write("<script>alert('Data Not Deleted');window.location.href='/admin/Viewhotel';</script>");
            }
            }
            return View();
        }
        public ActionResult Addhotel()
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        [HttpPost]
        public ActionResult Addhotel(string city, string hotel, string haddress, string rent, HttpPostedFileBase file)
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else {
             
                if (file != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/image/"), file.FileName);
                    file.SaveAs(path);
                    string cmd = "insert into tbl_hotel values ('" + city + "','" + hotel + "','" + rent + "','" + DateTime.Now.ToString() + "','" + file.FileName + "','" + haddress + "')";
                    if (db.myinsertupdatedelete(cmd))
                    {
                        Response.Write("<script>alert('Your Details Succesfully Saved.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Your Details Not Saved.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Choose Photo')</script>");
                }
               
            }
            return View();
        }
    }
}