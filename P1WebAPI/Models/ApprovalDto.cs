using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApprovalDto
    {
        public ApprovalDto(Guid employeeId, Guid ticketId, string approvalStatus)
        {
            this.employeeId = employeeId;
            this.ticketId = ticketId;
            this.approvalStatus = approvalStatus;
        }

        public Guid employeeId { get; set; }
        public Guid ticketId { get; set; }
        public string approvalStatus { get; set; }
    }
}
