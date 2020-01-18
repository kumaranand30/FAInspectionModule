using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAInspectionModuleMVCEntities.BusinessEntities
{
    public class DeptWiseParameter
    {
        public int ID { get; set; }
        public int ParameterID { get; set; }
        public string ParameterName { get; set; }
        public bool IsActive { get; set; }
        public int DeptID { get; set; }
        public string DpetName { get; set; }
        public int AddedID { get; set; }
    }
}
