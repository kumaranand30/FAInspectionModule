using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAInspectionModuleMVCEntities.BusinessEntities
{
    public class InspectionSummaryList
    {
        public InspectionSummaryList()
        {
            Column = new List<Columns>();
            Row = new List<DataTableForSummary>();
        }
        public List<DataTableForSummary> Row { get; set; }
        public List<Columns> Column { get; set; }
       
    }
}
