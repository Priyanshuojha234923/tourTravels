using Antlr.Runtime.Misc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tourTravels.Models;

namespace tourTravels.Controllers
{
    public class HomeController : Controller
    {
        DBManager db=new DBManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult ContactUs()
        {
          

            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(string name ,string email, string phone ,string msg)
        {
            
            string cmd = "insert into tbl_contact values('" + name + "','" + email + "','" + phone + "','" + msg + "')";
            if(db.myinsertupdatedelete(cmd))
            {
                Response.Write("<script>alert('Message Send')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error! send Message')</script>");
            }

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( string pass,string uid)
        {
            string type = "";
            string cmd = "select * from tbl_login where userid='" + uid + "' and password='" + pass + "'and status=1";
            DataTable dt = db.getallrecord(cmd);
            if (dt.Rows.Count > 0)
            {
                type = dt.Rows[0]["type"].ToString();
                if (type == "manager")
                {
                    Session["uid"] = uid;
                    Response.Redirect("/manager/index");
                }
                else if (type == "admin")
                {
                    Session["aid"] = uid;
                    Response.Redirect("/admin/index");
                }
                else
                {
                    Response.Write("<script>alert('Error')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('user id and password not matched')</script>");
            }

            return View();
        }
        [HttpGet]
        public JsonResult getplace()
        {
            //string[] arr=new string[100];
            string data = "";
            string cmd = "select place from tbl_place";
            DataTable dt = db.getallrecord(cmd);
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    //arr[i] = Console.ReadLine();

                    data += "<option value='"+ dt.Rows[i]["place"] + "'>" + dt.Rows[i]["place"] +"</option>";
                   
                }
            }
            else
            {
                //"string.Empty";
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult booking()
        {
            return View();  
        }
        [HttpPost]
       public ActionResult booking(string Txtname,string Txtemail,string Txtmobile,string Desti,string Clocation)
        {
          //string data = "";
            
            string cmd = "insert into Booking values('" + Txtname + "','"+Txtemail+"','"+Txtmobile+"','"+Desti+"','"+Clocation+"','"+DateTime.Now.ToString()+"')";
            if (db.myinsertupdatedelete(cmd))
            {
               
                Response.Redirect("/home/index");
                Response.Write("<script>alert('data save sucessfully')</script>");
            }
            else
            {
               
                Response.Redirect("/home/index");
                Response.Write("<script>alert('data not')</script>");
            }
            return View();
        }
        public ActionResult feedback()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult feedback(string txtname,string msg,string rating)
        {
            string cmd = "insert into feedback values('" +  txtname + "','" + msg  +"','"+rating+"','"+DateTime.Now.ToString()+"')";
           
            if (db.myinsertupdatedelete(cmd))
            {
                Response.Write("<script>alert('data inserted')</script>");
            }
            else
            {
                Response.Write("<script>alert('data not inserted')</script>");
            }
            return View();
        }
    }
}