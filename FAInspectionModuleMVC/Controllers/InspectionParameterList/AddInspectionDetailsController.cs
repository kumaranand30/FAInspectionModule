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
    public class AddInspectionDetailsController : Controller
    {
        BL.AddInspectionDetails addBM = new BL.AddInspectionDetails();
        BL.InspectionParameterList para = new BL.InspectionParameterList(); 
        // GET: AddInspectionDetails
        public ActionResult AddCuttingInspectionDetails(string name)
        {
            return View();
        }
     

        [HttpPost]
        public JsonResult GetWONOForCuttingInspection(int deptID)
        {
            List<BO.WoList> woList = new List<BO.WoList>();
            woList = addBM.GetWONOForCuttingInspection(deptID);
            return Json(woList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSRNOForWONOCuttingInspection(string wono, string woYear, int deptID)
        {
            List<BO.SreialNO> woList = new List<BO.SreialNO>();
            woList = addBM.GetSRNOForWONOCuttingInspection(wono,woYear,deptID);
            return Json(woList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetParameterListForDept(int deptID)
        {
            List<BO.DeptWiseParameter> paraList = new List<BO.DeptWiseParameter>();
            paraList = para.GetParameterListForDept(deptID);
            return Json(paraList, JsonRequestBehavior.AllowGet);
        }

       [HttpPost]
        public JsonResult GetOperatorDetailsforWONO(string wono, string srno, string woYear, int deptID)
        {
            BO.Operator op = new BO.Operator();
            op = addBM.GetOperatorDetailsforWONOForCutting(wono, srno, woYear, deptID);
            return Json(op, JsonRequestBehavior.AllowGet);
        }

       [HttpPost]
       public JsonResult GetCheckedByName()
       {
           BO.Operator op = new BO.Operator();
           op.Name = Convert.ToString(Session["FA_userName"]);
           return Json(op, JsonRequestBehavior.AllowGet);
       }

       [HttpPost]
       public JsonResult GetGlassDetailsforWONOForCutting(string wono, string srno, string woYear)
       {
           BO.PredefineValue op = new BO.PredefineValue();
           op = addBM.GetGlassDetailsforWONOForCutting(wono, srno, woYear);
           return Json(op, JsonRequestBehavior.AllowGet);
       }

        [HttpPost]
        public JsonResult AddCuttingInspectionData(BO.InspectionDetails insp, List<BO.ParameterTypeTableValue> inspectionValue)
        {
            insp.AddedBY = Convert.ToInt32(Session["FA_userID"]);
             string message = "";
            if (inspectionValue != null)
            {
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("ParamID");
                dataTable.Columns.Add("ParamValue");

                dataTable.TableName = "PT_InspectionDetails";

                foreach (BO.ParameterTypeTableValue element in inspectionValue)
                {
                    DataRow row = dataTable.NewRow();

                    row["ParamID"] = element.ParamID;
                    row["ParamValue"] = element.ParamValue;

                    dataTable.Rows.Add(row);
                }
                message = addBM.AddCuttingInspectionData(insp, dataTable);
                
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDepartmentForInspection()
        {
            List<BO.InspectionDepartment> dept = new List<BO.InspectionDepartment>();
            dept = para.GetDepartmentForInspection();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSummaryListForDepartmentWise(int deptID)
        {
            BO.InspectionSummaryList dt = new BO.InspectionSummaryList();
            dt = addBM.GetSummaryListForDepartmentWise(deptID);
            return Json(dt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteInspectionDetails(int autoID, int deptID)
        {
            int deleteby = Convert.ToInt32(Session["FA_userID"]);
            BO.InspectionSummaryList dt = new BO.InspectionSummaryList();
            dt = addBM.DeleteInspectionDetails(autoID, deleteby, deptID);
            return Json(dt, JsonRequestBehavior.AllowGet);
        }
    }
}