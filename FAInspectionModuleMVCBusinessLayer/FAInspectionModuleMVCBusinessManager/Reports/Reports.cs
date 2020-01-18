using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using BO = FAInspectionModuleMVCEntities.BusinessEntities;
using DB = FAInspectionModuleMVCDataLayer;

namespace FAInspectionModuleMVCBusinessLayer.FAInspectionModuleMVCBusinessManager.Reports
{
    public class Reports
    {
        DB.FAInspectionModuleMVCDataManager db = new DB.FAInspectionModuleMVCDataManager();
        public BO.InspectionSummaryList GetInspectionSummaryListFiltered(int deptID, string wono, DateTime from, DateTime to)
        {
            DataTable deptDL = new DataTable();
            deptDL = db.GetInspectionSummaryListFiltered(deptID,wono,from,to);
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
    }
}
