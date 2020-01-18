using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAInspectionModuleMVCEntities.BusinessEntities
{
    public class LoginDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public int UserID { get; set; }
        public string UType { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string EmpID { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}
