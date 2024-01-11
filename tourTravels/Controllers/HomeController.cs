using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
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
        encpassword epass = new encpassword();
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
                name = "";
                email = "";
                phone = "";
                msg = "";
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
            string cmd2 = "select * from tbl_login where userid='" + uid + "'";
            DataTable dt2=db.getallrecord(cmd2);
            if(dt2.Rows.Count>0)
            {
                string logpass = epass.Decryption(dt2.Rows[0]["password"].ToString());
                if(logpass == pass)
                {
                    type = dt2.Rows[0]["type"].ToString();
                  if(type == "user")
                    {
                        Session["uid"] = uid;

                        Response.Redirect("/user/index");
                    }
                    else if(type == "admin")
                    {
                        Session["aid"] = uid;

                        Response.Redirect("/admin/index");
                    }
                  else if(type == "manager")
                    {
                        Session["mid"] = uid;

                        Response.Redirect("/manager/index");
                    }
                }
                else
                {
                    Response.Write("<script>alert('user id and password not matched')</script>");
                }

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
       public ActionResult booking(string Txtname,string Txtemail,string Txtmobile,string Desti,string Clocation,string txtdate,string nop)
        {
          //string data = "";
            
            string cmd = "insert into Booking values('" + Txtname + "','"+Txtemail+"','"+Txtmobile+"','"+Desti+"','"+Clocation+"','"+txtdate+"','"+DateTime.Now.ToString()+"','"+nop+"')";
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
        public ActionResult vplace(string id)
        {
            ViewBag.pid = id;
            return View();
        }
      public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string txtname,string txtemail,string txtmobile,string txtpass,string txtcpass)
        {
            try
            {
              
                if (txtpass != null && txtcpass != null && txtname != null && txtmobile != null && txtemail != null && txtpass != "" && txtcpass != "" && txtname != "" && txtmobile != "" && txtemail != "")
                {
                    encpassword epass = new encpassword();
                    string password = epass.Encryption(txtpass);
                    ViewBag.name = password;
                    string cpassword = epass.Encryption(txtcpass);
                    ViewBag.txt = cpassword;
                    if (password == cpassword)
                    {
                        string cmd = "insert into registration values('" + txtname + "','" + txtemail + "','" + txtmobile + "','" + password + "','" + DateTime.Now.ToString() + "')";
                        string cmd2 = "insert into tbl_login values('" + txtemail + "','" + password + "','user',1)";
                        if (db.myinsertupdatedelete(cmd) && db.myinsertupdatedelete(cmd2))
                        {
                            ViewBag.msg = " Registration successfully";
                          
                        }
                        else
                        {
                            ViewBag.msg = " Registration not  successfull";
                           
                        }
                    }
                    else
                    {
                        ViewBag.msg = "password and confirm password not matched";
                      
                    }
                }
                else
                {
                    ViewBag.msg = "please fill all fields";
                  
                }
            }
            catch (Exception e)
            {
                ViewBag.msg="Email Already Exist";

            }
            return View();
        }
        public ActionResult feedbackview()
        {
            return View();
        }
        public JsonResult gethotel(string place)
        {
            string data = "";
            string cmd = "select hotel from tbl_hotel inner join tbl_place on tbl_hotel.city=tbl_place.place where place='"+place+"'";
            DataTable dt = db.getallrecord(cmd);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    data += "<option value='"+ dt.Rows[i]["hotel"] + "'>" + dt.Rows[i]["hotel"] +"</option>";
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}