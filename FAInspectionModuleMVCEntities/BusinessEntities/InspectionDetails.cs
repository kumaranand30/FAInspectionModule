using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAInspectionModuleMVCEntities.BusinessEntities
{
    public class InspectionDetails
    {
        public string WONO { get; set; }
        public string SrNO { get; set; }
        public string WOYear { get; set; }
        public string SpecialInstruction { get; set; }
        public int VerificationBY { get; set; }
        public string CheckedBY { get; set; }
        public int AddedBY { get; set; }
        public int DeptID { get; set; }
     
    }
}
