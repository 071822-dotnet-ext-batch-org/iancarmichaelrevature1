using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApprovalDto
    {
        public Guid employeeId { get; set; }
        public Guid ticketId { get; set; }
        public string approvalStatus { get; set; }


    }
}
