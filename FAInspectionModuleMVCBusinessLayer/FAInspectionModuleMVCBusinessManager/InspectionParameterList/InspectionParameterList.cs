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
    public class InspectionParameterList
    {
        DB.FAInspectionModuleMVCDataManager db = new DB.FAInspectionModuleMVCDataManager();

        public List<BO.InspectionDepartment> GetDepartmentForInspection()
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetDepartmentForInspection();
            List<BO.InspectionDepartment> deptBL = new List<BO.InspectionDepartment>();

            if (deptDL.Rows.Count != 0)
            {
                foreach (DataRow row in deptDL.Rows)
                {
                    BO.InspectionDepartment dept = new BO.InspectionDepartment();
                    dept.DeptID  = Convert.ToInt32(row["ID"]);
                    dept.DeptName = Convert.ToString(row["Name"]);
                    deptBL.Add(dept);
                }
            }
            return deptBL;
        }

        public List<BO.DeptWiseParameter> AddParameterForDept(BO.DeptWiseParameter parameter)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.AddParameterForDept(parameter.ParameterName, parameter.DeptID, parameter.AddedID);
            List<BO.DeptWiseParameter> deptBL = new List<BO.DeptWiseParameter>(); 
            deptBL = GetParameterListForDept(parameter.DeptID);
            return deptBL;
        }

        public List<BO.DeptWiseParameter> GetParameterListForDept(int deptID)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetParameterListForDept(deptID);
            List<BO.DeptWiseParameter> deptBL = new List<BO.DeptWiseParameter>();

            if (deptDL.Rows.Count != 0)
            {
                foreach (DataRow row in deptDL.Rows)
                {
                    BO.DeptWiseParameter dept = new BO.DeptWiseParameter();
                    dept.ID = Convert.ToInt32(row["ID"]);
                    dept.ParameterID = Convert.ToInt32(row["Parameter ID"]);
                    dept.ParameterName = Convert.ToString(row["Parameter Name"]);
                    dept.IsActive = Convert.ToBoolean(row["Is Active"]);
                    deptBL.Add(dept);
                }
            }
            return deptBL;
        }

        public List<BO.DeptWiseParameter> UpdateParameterForDept(BO.DeptWiseParameter parameter)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.UpdateParameterForDept(parameter.ParameterID,parameter.DeptID,parameter.IsActive,parameter.AddedID);
            List<BO.DeptWiseParameter> deptBL = new List<BO.DeptWiseParameter>();
            deptBL = GetParameterListForDept(parameter.DeptID);
            return deptBL;
        }

        public List<BO.DeptWiseParameter> DeleteParameterListForDept(BO.DeptWiseParameter parameter)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.DeleteParameterListForDept(parameter.ParameterID, parameter.DeptID,  parameter.AddedID);
            List<BO.DeptWiseParameter> deptBL = new List<BO.DeptWiseParameter>();
            deptBL = GetParameterListForDept(parameter.DeptID);
            return deptBL;
        }
    }
}
