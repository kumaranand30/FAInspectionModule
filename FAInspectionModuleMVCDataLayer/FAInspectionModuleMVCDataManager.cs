using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAC = FAInspectionModuleMVCDBConnector;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;   

namespace FAInspectionModuleMVCDataLayer
{
    public class FAInspectionModuleMVCDataManager
    {
        string sqlCommandSting;

        public DataTable ValidateLogin(string loginID, string loginPassword)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_WebLoginDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@EmpID", loginID.Trim());
                    objCommand.Parameters.AddWithValue("@pswrd", loginPassword.Trim());
                    
                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable GetDepartmentForInspection()
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_GetInspectionDepartments";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure; 

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable AddParameterForDept(string parameterName, int deptID, int addedBy)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_InsertInspectionParameter";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ParamName", parameterName.Trim());
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                    objCommand.Parameters.AddWithValue("@AddedBy", addedBy);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable GetParameterListForDept(int deptID)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_GetParameterList";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }
        public DataTable UpdateParameterForDept(int parameterID, int deptID,bool isActive, int modifiedBY)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_UpdateInspectionParameter";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure; 
                    objCommand.Parameters.AddWithValue("@ParamID", parameterID); 
                    objCommand.Parameters.AddWithValue("@DeptID", deptID); 
                    objCommand.Parameters.AddWithValue("@IsActive", isActive); 
                    objCommand.Parameters.AddWithValue("@ModifiedBy", modifiedBY); 
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable DeleteParameterListForDept(int paramID, int deptID, int deletedBY)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_DeleteInspectionParameter";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@ParamID", paramID);
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                    objCommand.Parameters.AddWithValue("@DeletedBy", deletedBY);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable GetWONOListForCutting(int deptID)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_GetWONo";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure; 
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }


        public DataTable GetSRNOforWONOForCutting(string wono, string woYear, int deptID)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_GetSrNo";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@WONo", wono);
                    objCommand.Parameters.AddWithValue("@WOYear", woYear);
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable GetOperatorDetailsforWONOForCutting(string wono, string srno, string woYear, int deptID)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_GetOperatorDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@WONo", wono);
                    objCommand.Parameters.AddWithValue("@SrNo", srno);
                    objCommand.Parameters.AddWithValue("@WOYear", woYear);
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable GetGlassDetailsforWONOForCutting(string wono, string srno, string woYear)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_GetGlassDetails";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@WONo", wono);
                    objCommand.Parameters.AddWithValue("@SrNo", srno);
                    objCommand.Parameters.AddWithValue("@WOYear", woYear); 
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }


        public DataTable AddInspectionDetailsForCutting(string wono, string srNO, string woYear, string splInstruction, int verifiedBY,
            int addedBY, int deptID)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_InsertInspectionMaster";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@WONo", wono);
                    objCommand.Parameters.AddWithValue("@SrNo", srNO);
                    objCommand.Parameters.AddWithValue("@WOYear", woYear);
                    objCommand.Parameters.AddWithValue("@Splinstruction", splInstruction);
                    objCommand.Parameters.AddWithValue("@VerifiedBy", verifiedBY); 
                    objCommand.Parameters.AddWithValue("@AddedBy", addedBY);
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                   
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public int AddInspectionDetailsForCutting(DataTable dataTable,Dictionary<object, object> parameterList)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            int i = 0;
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                   


                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in parameterList)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    if (dataTable != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_InspectionDetails";
                        param1.Value = dataTable;
                        param1.TypeName = "PT_InspectionDetails";
                        param1.SqlDbType = SqlDbType.Structured;
                        cmd.Parameters.Add(param1);
                    }
                    DataSet ds = new DataSet();
                    cmd.CommandText = "USP_InsertInspectionDetails";
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();
                    i = 1;

                  
                    connection.Close();
                    return i;
                 
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

        public DataTable GetSummaryListForDepartmentWise(int deptID)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_InspectionSummary";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@DeptID", deptID); 
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }


        public DataTable DeleteInspectionDetails(int autoID,int deleteby)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandSting = "USP_DeleteInspectionRecord";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@AutoID", autoID);
                    objCommand.Parameters.AddWithValue("@DeletedBy", deleteby);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }


        public DataTable GetInspectionSummaryListFiltered(int deptID, string wono, DateTime from, DateTime to)
        {
            FAC.DBConnection objConn = new FAC.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                //connection.Open();
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string fromDate = from.ToString("dd-MMM-yyyy");
                    string toDate = to.ToString("dd-MMM-yyyy");
                    sqlCommandSting = "USP_InspectionSummarySearchwise";
                    SqlCommand objCommand = new SqlCommand(sqlCommandSting, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@DeptID", deptID);
                    objCommand.Parameters.AddWithValue("@WONo", wono);
                    objCommand.Parameters.AddWithValue("@FromDate", fromDate);
                    objCommand.Parameters.AddWithValue("@ToDate", toDate);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dtLoginDetails = new DataTable();

                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;
                        _Data.Fill(dtLoginDetails);
                    }
                    connection.Close();
                    return dtLoginDetails;
                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }

        }

    }
}
