using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class Reimbursement
    {
        public int ReimbursementId { get; set; }
        public int EmployeeId { get; set; }
        public int ReimbursementTypeId { get; set; }
        public int ReimbursementAmount { get; set; }

    }
}