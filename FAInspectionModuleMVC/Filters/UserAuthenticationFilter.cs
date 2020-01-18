using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data;
using System.Data.Sql;
using System.Web.Mvc.Filters;

namespace FAInspectionModuleMVC.Filters
{
    public class UserAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Check Session is Empty Then set as Result is HttpUnauthorizedResult 
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["FA_userID"])))
            {
                HttpCookie reqCookies = filterContext.HttpContext.Request.Cookies["FA_userCookies"];
                filterContext.HttpContext.Session["FA_userID"] = reqCookies["FA_userID"].ToString();
                filterContext.HttpContext.Session["FA_userName"] = reqCookies["FA_userName"].ToString();
                filterContext.HttpContext.Session["FA_Password"] = reqCookies["FA_Password"].ToString();
                filterContext.HttpContext.Session["FA_DepType"] = reqCookies["FA_DepType"].ToString();

                //  filterContext.Result = new RedirectResult("~/Home/index");
            }

        }


        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //We are checking Result is null or Result is HttpUnauthorizedResult 
            // if yes then we are Redirect to Error View
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Home/index");

            }
        }


    }
}