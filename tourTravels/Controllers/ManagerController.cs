using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using tourTravels.Models;

namespace tourTravels.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        encpassword epass=new encpassword();
        DBManager db=new DBManager();
        public ActionResult Index()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult AddPlace()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        [HttpPost]
        public ActionResult AddPlace(string place, string des, HttpPostedFileBase pic,string nprice,string osprice)
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
                if (pic != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/image/"), pic.FileName);
                    pic.SaveAs(path);

                    string cmd = "insert into tbl_place values('" + place + "','" + des + "','" + pic.FileName + "','" + nprice + "','" + osprice + "')";
                    if (db.myinsertupdatedelete(cmd))
                    {
                        ViewBag.msg = "data inserted";
                        Response.Write("<script>alert('your details succesfully saved.');window.location.href='/manager/addplace';</script>");
                    }
                    else
                    {

                        ViewBag.msg = "data inserted";
                        Response.Write("<script>alert('error');window.location.href='/manager/addplace';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Choose Photo')</script>");
                }

               
            }
            return View();
        }
        [HttpGet]
        public ActionResult ViewBooking()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult Deletebooking( string del)
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
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
            }
            return View();
        }
        public ActionResult Logout()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("/home/index");
            return View();
        }
        public ActionResult ViewRegistration()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult cpassword() { return View(); }
        [HttpPost]
        public ActionResult cpassword(string opass,string cnpass,string npass)
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
                if (npass == cnpass)
                {
                    string lpass = epass.Encryption(npass);
                    string cmd = "update tbl_login set password='" + lpass + "' where userid='" + Session["mid"].ToString() +"' ";
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
            }            return View();
        }
        public ActionResult Viewplace()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult dplace(string id)
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
                string cmd = "delete from tbl_place where pid='" + id + "'";
                if (db.myinsertupdatedelete(cmd))
                {
                    Response.Write("<script>alert('Data Deleted');window.location.href='/manager/Viewplace';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data Not Deleted');window.location.href='/manager/Viewplace';</script>");
                }
            }
            return View();
        }
        public ActionResult Bhotel()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        [HttpPost]
        public ActionResult Bhotel(string city,string hotel,string price,HttpPostedFileBase file)
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
                if (file != null)
                {
                    string pic = Path.Combine(Server.MapPath("~/Content/Image/"), file.FileName);
                    file.SaveAs(pic);
                    string cmd = "insert into tbl_hotel values('" + city + "','" + hotel + "','" + price + "','" + DateTime.Now.ToString() + "','" + file.FileName + "')";
                    if (db.myinsertupdatedelete(cmd))
                    {
                        Response.Write("<script>alert('data inserted')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('data not inserted')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please choose Image File')</script>");
                }
              
            }
            return View();
        }
        public ActionResult viewcontact()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult vhbooking()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        public ActionResult Addhotel()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View();
        }
        [HttpPost]
        public ActionResult Addhotel(string city,string hotel,string haddress,string rent,HttpPostedFileBase file)
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
              if(file != null)
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
                    Response.Write("<script>alert('Please Choose File')</script>");
                }
            }
            return View();
        }
        public ActionResult Viewhotel()
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            return View() ;
        }
        public ActionResult dhotel(string del)
        {
            if (Session["mid"] == null)
            {
                Response.Redirect("/home/login");

            }
            else
            {
                string cmd = "delete from tbl_hotel  where id='" + del + "'";
                if (db.myinsertupdatedelete(cmd))
                {
                    Response.Write("<script>alert('Data Deleted');window.location.href='/manager/Viewhotel';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data Not Deleted');window.location.href='/manager/Viewhotel';</script>");
                }
            }
            return View();
        }

    }
}