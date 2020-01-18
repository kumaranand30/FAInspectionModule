using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using BO = FAInspectionModuleMVCEntities.BusinessEntities;
using DM = FAInspectionModuleMVCDataLayer.FAInspectionModuleMVCDataManager;

namespace FAInspectionModuleMVCBusinessLayer.FAInspectionModuleMVCBusinessManager.Login
{
    public class Login
    {
        public BO.LoginDetails ValidateLogin(string name, string pass)
        {

            DataTable loginData = new DataTable();
            DM dm = new DM();
            //DB.GetMyREQDBManager getmyreqdatamanager = new DB.GetMyREQDBManager();
            loginData = dm.ValidateLogin(name, pass);

            BO.LoginDetails loggedInDetails = new BO.LoginDetails();


            if (loginData.Rows.Count > 0)
            {

                foreach (DataRow row in loginData.Rows)
                {

                    loggedInDetails.UserID = Convert.ToInt32(row["UserID"]);
                    loggedInDetails.UserName = Convert.ToString(row["userName"]);
                    loggedInDetails.UType = Convert.ToString(row["UType"]);
                    loggedInDetails.EmpID = Convert.ToString(row["EmpId"]);
                    loggedInDetails.ContactNo = Convert.ToString(row["ContactNo"]);
                    loggedInDetails.Email = Convert.ToString(row["email_ID"]);
                    
                }
            }
            return loggedInDetails;
        }
    }
}
