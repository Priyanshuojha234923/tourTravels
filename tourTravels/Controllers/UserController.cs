using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using tourTravels.Models;

namespace tourTravels.Controllers
{
    public class UserController : Controller
    {
        encpassword epass=new encpassword();
        DBManager db=new DBManager();
        // GET: User
        public ActionResult Index()
        {

            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
                ViewBag.Uid = Session["uid"];
            }
            return View();
                       
        }
      
        public ActionResult viewticket()
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult Uticket()
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult Rating()
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            string id = Session["uid"].ToString();
            string cmd = "select * from registration where email='"+id+"'";
            DataTable dt = db.getallrecord(cmd);
            if (dt.Rows.Count > 0)
            {
                ViewBag.name = dt.Rows[0]["name"];
            }

            return View();
        }
        [HttpPost]
        public ActionResult Rating(string txtname, string msg, string rating)
        {
            string cmd = "insert into feedback values('" + txtname + "','" + msg + "','" + rating + "','" + DateTime.Now.ToString() + "')";

            if (db.myinsertupdatedelete(cmd))
            {
                Response.Write("<script>alert('data inserted')</script>");
                txtname = null;
                msg = null;
                rating = null;
            }
            else
            {
                Response.Write("<script>alert('data not inserted')</script>");
            }
            return View();
        }
        public ActionResult Upassword(string uid)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        [HttpPost]
        public ActionResult Upassword(string opass, string cnpass, string npass)
        {

            if (npass == cnpass)
            {
                string lpass = epass.Encryption(npass);
                string id = Session["uid"].ToString();
                string cmd = "update tbl_login set password='" + lpass + "' where userid='" +id + "' ";
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
            return View();
        }
        public ActionResult Bhotel( string book)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else { 
            string id = Session["uid"].ToString();
            string cmd = "select * from registration where email='"+id+"'";
            string cmd2 = "select * from tbl_hotel where id='" + book + "'";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt =db.getallrecord(cmd);
            dt1=db.getallrecord(cmd2);
            if(dt1.Rows.Count > 0 && dt.Rows.Count > 0)
            {
                ViewBag.name = dt.Rows[0]["name"].ToString();
                ViewBag.email = dt.Rows[0]["email"].ToString();
                ViewBag.mobile = dt.Rows[0]["mobile"].ToString();
                ViewBag.city = dt1.Rows[0]["city"].ToString();
                ViewBag.hotel = dt1.Rows[0]["hotel"].ToString();
                  
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Bhotel(string txtname,string txtemail,string txtmobile,string txtcity,string txthotel,string nop,string txtcdate,string txtodate)
        {
            string cmd = "insert into hotel_booking values('" + txtname + "','" + txtemail + "','" + txtmobile + "','" + txtcity + "','" + txtcdate + "','" + txtodate + "','" + DateTime.Now.ToString() + "','" + nop + "','" + txthotel +"','1')";
            if (db.myinsertupdatedelete(cmd))
            {
                ViewBag.msg = "Data Inserted";
            }
            else
            {
                ViewBag.msg = "Data Not Inserted";
            }
            return View();
        }
        public ActionResult Booking()
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult vplace( string id)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            ViewBag.pid = id;
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
        public ActionResult bookticket(string id)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            string email = Session["uid"].ToString();
            string cmd = "select * from tbl_place where pid='"+id+"'";
            string cmd1 = "select * from registration where email='"+email+"'";
            DataTable dt = db.getallrecord(cmd);    
            DataTable dt1=db.getallrecord(cmd1);
            if(dt.Rows.Count > 0 && dt.Rows.Count>0)
            {
                ViewBag.place = dt.Rows[0]["place"];
                ViewBag.name = dt1.Rows[0]["name"];
                ViewBag.mobile = dt1.Rows[0]["mobile"];
            
            }

            return View();
        }
        [HttpPost]
        public ActionResult bookticket(string txtname, string txtemail, string txtmobile, string txtplace, string clocation, string jdate, string nop)
        {
            string cmd = "insert into Booking values('" + txtname + "','" + txtemail + "','" + txtmobile + "','" + txtplace + "','" + clocation + "','" + jdate + "','" + DateTime.Now.ToString() + "','" + nop + "')";
            if (db.myinsertupdatedelete(cmd))
            {
                Response.Write("<script>alert('data save sucessfully')</script>");
                Response.Redirect("/user/viewticket");
            }
            else
            {

            
                Response.Write("<script>alert('data not')</script>");
        
            }
            return View();
        }
        public ActionResult vhotel()
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
    }
}