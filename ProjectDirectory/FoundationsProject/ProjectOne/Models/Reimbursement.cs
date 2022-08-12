using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Reimbursement
    {
        private int reimbursementTypeId;
        public int ReimbursementTypeId
        {
            get { return reimbursementTypeId; }
            set { reimbursementTypeId = value; }
        }

        private double reimbursementAmount;
        public double ReimbursementAmount
        {
            get { return reimbursementAmount; }
            set { reimbursementAmount = value; }
        }

    }
}


/* 
.: v0.003: 07.28.2022;
   Corrected a namespace error.
   Feeling confident in the knowledge I have amassed thus far.
*/

/* 
.: v0.002: 07.27.2022;
   Still trying to get the hang of these Getters and Setters,
   as well as dealing with OOP design principles.
   I need simple answers to stupid things like: 
   "Are my variables I've declared in this class being accessed 
   in my main method, or am I being redundant?"
   
   On the bright side, I feel like I'm just a few stupid 
   questions away from a serious 'Ah-hah!' Moment. 
*/