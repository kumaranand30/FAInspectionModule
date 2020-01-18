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
using BL = FAInspectionModuleMVCBusinessLayer.FAInspectionModuleMVCBusinessManager.Reports; 

namespace FAInspectionModuleMVC.Controllers.Reports
{
    public class ReportsController : Controller
    {
        BL.Reports reportBM = new BL.Reports();
        // GET: Reports
        public ActionResult ReportView()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetInspectionSummaryListFiltered(int deptID, string wono, string from, string to)
        {
            BO.InspectionSummaryList list = new BO.InspectionSummaryList();
            list = reportBM.GetInspectionSummaryListFiltered(deptID, wono, Convert.ToDateTime(from), Convert.ToDateTime(to));
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}