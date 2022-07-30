using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*
.: Update: 07.28.2022; 
After speaking with Mark after work on Thursday, I've decided to take the time to proceed
with the project as far as I can with the C# I already know, and refactor the code later, 
after learning the technologies I'll be using in the future. This contradicts my earlier
comment/plan. Can't afford to be lazy when you're still learning.

.: v0.002: 07.27.2022;
I imagine once we get to SQL, we'll all use a database to store the data here.
Therefore, in the interest of not having to go back and refactor over and over, 
I will just create a list of objects to serve as a template.
*/



namespace ProjectOne

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
