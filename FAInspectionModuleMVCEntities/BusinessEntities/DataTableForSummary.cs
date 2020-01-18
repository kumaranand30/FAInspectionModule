using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAInspectionModuleMVCEntities.BusinessEntities
{
    public class DataTableForSummary
    {
        public DataTableForSummary()
        { 
            Row = new List<Rows>();
        }
      
        public List<Rows> Row { get; set; }
        public int ID { get; set; }
    }
}
