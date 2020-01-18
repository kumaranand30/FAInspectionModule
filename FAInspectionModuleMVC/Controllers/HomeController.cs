using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO = FAInspectionModuleMVCEntities.BusinessEntities;
using LBM = FAInspectionModuleMVCBusinessLayer.FAInspectionModuleMVCBusinessManager.Login.Login ;
using FAInspectionModuleMVC.Filters;
using BL = FAInspectionModuleMVCBusinessLayer.FAInspectionModuleMVCBusinessManager.InspectionParameterList;

namespace FAInspectionModuleMVC.Controllers
{
    public class HomeController : Controller
    {
        LBM lbm = new LBM();
        public ActionResult Index()
        {
            BO.LoginDetails logindata = new BO.LoginDetails();
            string User_name = string.Empty;
            string User_color = string.Empty;
            HttpCookie reqCookies = Request.Cookies["FA_userInfo"];

            if (reqCookies != null)
            {
                logindata.UserName = reqCookies["FA_userName"].ToString();
                logindata.Password = reqCookies["FA_Password"].ToString();
                logindata.RememberMe = true;
            }

            return View("index", logindata); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult login(BO.LoginDetails loginDetails)
        {

            // BE.LoginEntites loginEntities = new BE.LoginEntites();
            var name = loginDetails.UserName;
            var pass = loginDetails.Password;
            Boolean rememberme = Convert.ToBoolean(loginDetails.RememberMe);


            BO.LoginDetails logindata = new BO.LoginDetails();

            logindata = lbm.ValidateLogin(name, pass);
            if (logindata.UserID != 0)
            {
                Session["FA_userID"] = logindata.UserID;
                Session["FA_userName"] = logindata.UserName;
                Session["FA_DepType"] = logindata.UType;

                HttpCookie tracker_userCookies = new HttpCookie("FA_userCookies");
                tracker_userCookies["FA_userID"] = Convert.ToString(logindata.UserID);
                tracker_userCookies["FA_userName"] = logindata.UserName; ;
                tracker_userCookies["FA_Password"] = pass;
                tracker_userCookies["FA_DepType"] = logindata.UType;
                Response.Cookies.Add(tracker_userCookies);

                RememberMe(name, pass, rememberme);
                //  return RedirectToAction("Dashboard");
                BL.InspectionParameterList list = new BL.InspectionParameterList();
                List<BO.InspectionDepartment> dept = new List<BO.InspectionDepartment>();
                dept = list.GetDepartmentForInspection();
                ViewBag.list = "abcd";
                ViewBag.Menulist = dept; 
                return RedirectToAction("DepartmentWiseList", "InspectionList");
            }
            else
            {
                logindata.LoginErrorMessage = "Wrong Username or Password.";
                //  return View("index");
                return View("index", logindata);
            }
        }

        private void RememberMe(String name, String password, Boolean rememberme)
        {

            if (rememberme)
            {
                HttpCookie tracker_userInfo = new HttpCookie("FA_userInfo");
                tracker_userInfo["FA_userName"] = name;
                tracker_userInfo["FA_Password"] = password;
                tracker_userInfo.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(tracker_userInfo);

            }
            else
            {
                HttpCookie vms_userInfo = new HttpCookie("FA_userInfo");
                vms_userInfo.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(vms_userInfo);
            }



        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }

        [UserAuthenticationFilter]
        public JsonResult SideMenu()
        {
            BL.InspectionParameterList list = new BL.InspectionParameterList();
            List<BO.InspectionDepartment> dept = new List<BO.InspectionDepartment>();
            dept = list.GetDepartmentForInspection();
            ViewBag.Menulist = dept;
            return Json(dept, JsonRequestBehavior.AllowGet);

        }
    }
}