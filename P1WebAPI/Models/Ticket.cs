using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        public Ticket(Guid ticketId, Guid employeeId_Fk, string reimbursementDescription, decimal reimbursementAmount, string approvalStatus)
        {
            this.ticketId = ticketId;
            this.employeeId_Fk = employeeId_Fk;
            this.reimbursementDescription = reimbursementDescription;
            this.reimbursementAmount = reimbursementAmount;
            this.approvalStatus = approvalStatus;
        }

        public Guid ticketId { get; set; }
        public Guid employeeId_Fk { get; set; }
        public string reimbursementDescription { get; set; }
        public decimal reimbursementAmount { get; set; }
        public string approvalStatus { get; set; }

    }
}

/*
CREATE TABLE Tickets(
ticketId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
employeeId_Fk UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Employees(employeeId) NOT NULL,
reimbursementDescription NVARCHAR(255) NOT NULL,
reimbursementAmount MONEY NOT NULL,
approvalStatus NVARCHAR(8) DEFAULT 'Pending' NOT NULL
);
*/