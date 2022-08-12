using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models

{
    public class Employee
    {

// set the Employee's ID to be a private variable (for security purposes)
        private int employeeId;
// make EmployeeID a property so that it can be accessed outside of the class
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

// set the Employee's first name to be a private variable
        private string firstName;
// make FirstName a property (same as above)
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

// set the Employee's last name to be a private variable 
        private string lastName;
// make LastName a property (same as above)
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

// set the Employee's full name to be a private variable
        private string fullName;
// make FullName a property (same as above)
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

// set the Employee's email to be a private variable
        private string email;
// make Email a property (same as above)
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

//default constructor (Unsure if this is necessary)
/*Mark's notes: ". . .BUT if you create a parameterized constructor, 
                 you MUST create your own default constructor."   */
        public Employee()
        {

        }

// parameterized constructor (like Mark showed us)
public Employee(int employeeId, string firstName, string lastName, string fullName, string email)
        {
            this.EmployeeId = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FullName = fullName;
            this.Email = email;
        }
    }
}
