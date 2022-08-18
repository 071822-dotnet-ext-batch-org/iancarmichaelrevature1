using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UpdatedTicketDto
    {
        public UpdatedTicketDto(Guid ticketId, string firstName, string lastName, string approvalStatus)
        {
            this.ticketId = ticketId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.approvalStatus = approvalStatus;
        }

        public Guid ticketId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string approvalStatus { get; set; }
    }
}