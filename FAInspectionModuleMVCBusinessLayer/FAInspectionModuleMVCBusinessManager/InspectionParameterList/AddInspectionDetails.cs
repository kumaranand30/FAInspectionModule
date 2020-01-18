using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using BO = FAInspectionModuleMVCEntities.BusinessEntities;
using DB = FAInspectionModuleMVCDataLayer;

namespace FAInspectionModuleMVCBusinessLayer.FAInspectionModuleMVCBusinessManager.InspectionParameterList
{
    public class AddInspectionDetails
    {
        DB.FAInspectionModuleMVCDataManager db = new DB.FAInspectionModuleMVCDataManager();
        public List<BO.WoList> GetWONOForCuttingInspection(int deptID)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetWONOListForCutting(deptID);
            List<BO.WoList> deptBL = new List<BO.WoList>();

            if (deptDL.Rows.Count != 0)
            {
                foreach (DataRow row in deptDL.Rows)
                {
                    BO.WoList dept = new BO.WoList();
                    dept.WONO = Convert.ToString(row["WONo"]);
                    dept.WOYEAR = Convert.ToString(row["WOYear"]);
                    deptBL.Add(dept);
                }
            }
            else
            {
                BO.WoList dept = new BO.WoList();
                dept.WONO = "NA";
                dept.WOYEAR = "";
                deptBL.Add(dept);
            }
            return deptBL;
        }

        public List<BO.SreialNO> GetSRNOForWONOCuttingInspection(string wono, string woYear,int deptID)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetSRNOforWONOForCutting(wono,woYear,deptID);
            List<BO.SreialNO> deptBL = new List<BO.SreialNO>();

            if (deptDL.Rows.Count != 0)
            {
                foreach (DataRow row in deptDL.Rows)
                {
                    BO.SreialNO dept = new BO.SreialNO();
                    dept.SrNO = Convert.ToString(row["SrNo"]); 
                    deptBL.Add(dept);
                }
            }
            else
            {
                BO.SreialNO dept = new BO.SreialNO();
                dept.SrNO = "NA"; 
                deptBL.Add(dept);
            }
            return deptBL;
        }

        public BO.Operator GetOperatorDetailsforWONOForCutting(string wono, string srno, string woYear, int deptID)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetOperatorDetailsforWONOForCutting(wono,srno,woYear,deptID);
            BO.Operator deptBL = new BO.Operator();

            if (deptDL.Rows.Count != 0)
            {
                foreach (DataRow row in deptDL.Rows)
                {
                    
                    deptBL.ID = Convert.ToInt32(row["OperatorID"]);
                    deptBL.Name = Convert.ToString(row["UserName"]);
                    
                }
            }
            else
            {
                deptBL.ID = 0;
                deptBL.Name = "NA";
            }
            return deptBL;
        }
        public BO.PredefineValue GetGlassDetailsforWONOForCutting(string wono, string srno, string woYear)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetGlassDetailsforWONOForCutting(wono, srno, woYear);
            BO.PredefineValue deptBL = new BO.PredefineValue();

            if (deptDL.Rows.Count != 0)
            {
                foreach (DataRow row in deptDL.Rows)
                {

                    BO.PredefineValue list = new BO.PredefineValue();
                    list.Brand = Convert.ToString(row["Brand"]);
                    list.Description = Convert.ToString(row["Description"]);
                    list.FullDescription = Convert.ToString(row["FullDesc"]);
                    list.GlassDescription = Convert.ToString(row["Glass Description"]);
                    list.GlassType = Convert.ToString(row["GlassType"]);
                    list.Height = Convert.ToDecimal(row["Height"]);
                    list.Remarks = Convert.ToString(row["Remarks"]);
                    list.Thickness = Convert.ToString(row["Thickness"]);
                    list.Width = Convert.ToDecimal(row["Width"]);
                    list.WoNo = Convert.ToString(row["WOno"]);
                    deptBL = list;

                }
            }
             
            return deptBL;

        }

        public string AddCuttingInspectionData(BO.InspectionDetails insp, DataTable typeTable)
        {
            DataTable deptDL = new DataTable();
            int id = 0;
            string message = "";
            deptDL = db.AddInspectionDetailsForCutting(insp.WONO, insp.SrNO, insp.WOYear, insp.SpecialInstruction, insp.VerificationBY,  insp.AddedBY, insp.DeptID);
            if (deptDL.Rows.Count != 0)
            {
                foreach (DataRow row in deptDL.Rows)
                {
                    id = Convert.ToInt32(row["AutoID"]); 
                }
            }

            Dictionary<object, object> parameterList = new Dictionary<object, object>();

            parameterList.Add("AutoID", id);

            int i = db.AddInspectionDetailsForCutting(typeTable, parameterList);
            if (i != 0)
            {
                message = "ok";
            }
            return message; 
        }

        public BO.InspectionSummaryList GetSummaryListForDepartmentWise(int deptID)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetSummaryListForDepartmentWise(deptID);
            BO.InspectionSummaryList summary = new BO.InspectionSummaryList();
             int i = 0;
            if (deptDL.Columns.Count != 0)
            {
                foreach (DataColumn row in deptDL.Columns)
                {
                    BO.Columns col = new BO.Columns();
                    col.Name = Convert.ToString(row.ColumnName);
                    summary.Column.Add(col);
                        i++;
                }

                foreach (DataRow row in deptDL.Rows)
                {
                    BO.DataTableForSummary list = new BO.DataTableForSummary();
                    for (int j = 0; j < i; j++)
                    {
                        
                        if (summary.Column[j].Name == "ID")
                        {
                            list.ID = Convert.ToInt32(row[summary.Column[j].Name]);
                        }
                        else
                        {
                            BO.Rows ro = new BO.Rows();
                            ro.ColumneName = summary.Column[j].Name;
                            ro.ColumnValue = Convert.ToString(row[ro.ColumneName]);
                            list.Row.Add(ro);
                        }
                       
                       
                    }
                    summary.Row.Add(list);
                
                }
            }
            return summary;
        }


        public BO.InspectionSummaryList DeleteInspectionDetails(int autoID,int deleteby, int deptID)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.DeleteInspectionDetails(autoID,deleteby);
            BO.InspectionSummaryList summary = new BO.InspectionSummaryList();
            summary = GetSummaryListForDepartmentWise(deptID);
            return summary;
        }


    }
}
