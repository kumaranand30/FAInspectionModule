using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Newtonsoft.Json;
using FAInspectionModuleMVC.Filters;
using System.IO;
using System.Data;
using BO = FAInspectionModuleMVCEntities.BusinessEntities;
using BL = FAInspectionModuleMVCBusinessLayer.FAInspectionModuleMVCBusinessManager.InspectionParameterList;

namespace FAInspectionModuleMVC.Controllers.InspectionParameterList
{
    [UserAuthenticationFilter] 
    public class InspectionListController : Controller
    {
        BL.InspectionParameterList list = new BL.InspectionParameterList();
        // GET: InspectionParamterList
        public ActionResult DepartmentWiseList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDepartmentForInspection()
        {
            List<BO.InspectionDepartment> dept = new List<BO.InspectionDepartment>();
            dept = list.GetDepartmentForInspection();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddParameterForDept(string parameterName, int deptID)
        {
           
            int SessionuserID = Convert.ToInt32(Session["FA_userID"]);
            BO.DeptWiseParameter para = new BO.DeptWiseParameter();
            para.AddedID = SessionuserID;
            para.DeptID = deptID;
            para.ParameterName = parameterName;
            List<BO.DeptWiseParameter> paraList = new List<BO.DeptWiseParameter>();
            paraList = list.AddParameterForDept(para); 
            return Json(paraList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetParameterListForDept(int deptID)
        { 
            List<BO.DeptWiseParameter> paraList = new List<BO.DeptWiseParameter>();
            paraList = list.GetParameterListForDept(deptID);
            return Json(paraList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateParameterForDept(int parameterID, int deptID, bool isActive)
        {

            int SessionuserID = Convert.ToInt32(Session["FA_userID"]);
            BO.DeptWiseParameter para = new BO.DeptWiseParameter();
            para.AddedID = SessionuserID;
            para.DeptID = Convert.ToInt32(deptID);
            para.ParameterID = Convert.ToInt32(parameterID);
            para.IsActive = Convert.ToBoolean(isActive);
            List<BO.DeptWiseParameter> paraList = new List<BO.DeptWiseParameter>();
            paraList = list.UpdateParameterForDept(para);
            return Json(paraList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteParameterListForDept(int parameterID, int deptID)
        {

            int SessionuserID = Convert.ToInt32(Session["FA_userID"]);
            BO.DeptWiseParameter para = new BO.DeptWiseParameter();
            para.AddedID = SessionuserID;
            para.DeptID = Convert.ToInt32(deptID);
            para.ParameterID = Convert.ToInt32(parameterID); 
            List<BO.DeptWiseParameter> paraList = new List<BO.DeptWiseParameter>();
            paraList = list.DeleteParameterListForDept(para);
            return Json(paraList, JsonRequestBehavior.AllowGet);
        }

    }
}