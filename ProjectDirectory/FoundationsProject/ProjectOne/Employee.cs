using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*I imagine once we get to SQL, we'll all use a database to store the data here.
Therefore, in the interest of not having to go back and refactor over and over, 
I will just create a list of objects to serve as a template.*/

namespace ProjectOne

{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}