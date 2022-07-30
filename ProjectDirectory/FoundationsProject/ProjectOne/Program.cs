using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*This is just the planning phase of the program.*/

//Update: v0.004: 07.30.2022;
/*         Lots of small refactors in Program.cs:
           Also: I found a way to display trailing zeroes.
                 (This is important since we're dealing
                 with currency. Money ain't no game.)
           TODO: Use Exception Handling to catch errors.
                 (My dreams are haunted by these errors.)      
           TODO: Decide on either/or a List and/or Dictionary
                 to store data and mimic an SQL database.   */
                 
//v0.001:  Initial Birth of the program. 07.27.2022;
/*v0.002:  Revised the blueprint of program to exclude redudant variables. 07.27.2022;
           Also: added some simple dialogue box functionality to Program.cs
           Also: Experimented with Properties and out parameters, I'll have 
                 a few questions going into class tomorrow~ */
/*v0.003:  Lessons learned today about namespaces and classes: 
           namespace was previously ExpenseReimbursementSystem. 
           My neural pathways are always under construction.
           Also: I instanciated the Employee class in Program.cs
           Also: I parameterized a constructor for Employee
                 and reorganized my getters and setters.    */

// PROJECT ONE: Expense reimbursement system
namespace ProjectOne

{
    class Program
    {
        static void Main(string[] args)
        {

        Employee e = new Employee();
        Reimbursement r = new Reimbursement();

        
Restart1:
// Console prompts the User to input employee ID
        Console.WriteLine("Please enter your employee ID: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

// if the response is alphanumeric, the program will ask the user to re-enter the employee ID   
        if (employeeId.ToString().Any(char.IsLetter))
        {
            Console.WriteLine("Please enter your numeric employee ID: ");
            goto Restart1;
        }

        Console.WriteLine("You entered " + employeeId + ", is this correct? Yes or No.");
        string employeeIDAnswer = Console.ReadLine();
        // if yes continue and if no, repeat the process
        if (String.Equals("Yes", employeeIDAnswer, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Thank you.");
            e.EmployeeId = employeeId;
        }
        else
        {
            Console.Clear();
            goto Restart1; 
        }
        
Restart2:
// Console prompts the User to input employee first name
        Console.WriteLine("Please enter your first name: ");
        string firstName = Console.ReadLine();
            
// Console prompts the User to input employee last name
        Console.WriteLine("Please enter your last name: ");
        string lastName = Console.ReadLine();

// take both first and last name and combine them into one string
        string fullName = firstName + " " + lastName;

// ask the User if their fullName is correct
        Console.WriteLine("Is " + fullName + " correct?");
        string fullNameAnswer = Console.ReadLine();

// if yes continue and if no, repeat the process
        if (fullNameAnswer == "yes")
        {
            Console.WriteLine("Thank you, " + fullName + ".");
            e.FirstName = firstName;
            e.LastName = lastName;
            e.FullName = fullName;
        }
        else
        {
            Console.Clear();
            goto Restart2; 
        }

// Console prompts the User to input their company email address
        Console.WriteLine("Please enter your company email address: ");
        string email = Console.ReadLine();

/* If the email address does not contain the mandatory @revature.net, 
the program will prompt the user to enter a valid email address*/
        while (!email.Contains("@revature.net"))
        {
            Console.WriteLine("Please enter a valid email address: ");
            email = Console.ReadLine();
        }
        if
        (email.Contains("@revature.net"))
        {
            Console.WriteLine("Thank you, " + email + ".");
            e.Email = email;
        }


// Console prompts the User to input the type of reimbursement they are requesting from the enum I made in ReimbursementTypes.cs
        Console.WriteLine("Please enter the type of reimbursement you are requesting: ");
        Console.WriteLine("1. Food");
        Console.WriteLine("2. Lodging");
        Console.WriteLine("3. Travel");
        Console.WriteLine("4. Other");

// Convert the User's input to an integer
        int reimbursementTypeId = Convert.ToInt32(Console.ReadLine());
        r.ReimbursementTypeId = reimbursementTypeId;

// if the User input is 1, the program will print out "Food," and ask if this is correct.
        if (reimbursementTypeId == 1)
        {
            Console.WriteLine("Food,");
            Console.WriteLine("Is this correct?");

                //if the user input is yes, the program will continue.
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Thank you for your submission.");
                }


        }

// if the User input is 2, the program will print out "Lodging," and ask if this is correct.
        if (reimbursementTypeId == 2)
        {
            Console.WriteLine("Lodging,");
            Console.WriteLine("Is this correct?");

                //if the user input is yes, the program will continue.
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Thank you for your submission.");
                }
        }
// if the User input is 3, the program will print out "Travel," and ask if this is correct.
        if (reimbursementTypeId == 3)
        {
            Console.WriteLine("Travel,");
            Console.WriteLine("Is this correct?");

                //if the user input is yes, the program will continue.
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Thank you for your submission.");
                }
        }
// if the User input is 4, the program will print out "Other," and ask if this is correct.
        if (reimbursementTypeId == 4)
        {
            Console.WriteLine("Other,");
            Console.WriteLine("Is this correct?");

                //if the user input is yes, the program will continue.
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Please specify what type of Reimbursement this is.");
// store user response as a new type of reimbursement
                    string otherReimbursement = Console.ReadLine();
                    Console.WriteLine($"You've indicated this type of reimbursement is for {otherReimbursement}.");
                    Console.WriteLine("Thank you for your submission.");
                }
        }

Restart3:
// Console prompts the User to input the amount of reimbursement they are requesting
        Console.WriteLine("Please enter the amount of reimbursement you are requesting: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        // if the user input is not a numerical value, the program will prompt the user to re-enter the amount of reimbursement
        if (amount.ToString().Any(char.IsLetter))
        {
            Console.WriteLine("Please enter a numerical value: ");
            goto Restart3;
        }
        else
        {
        Console.WriteLine($"Thank you, {e.FullName}, you've input ${amount}.");
            r.ReimbursementAmount = amount;
        }
        {
            Console.WriteLine("Please enter a number. (It may help to omit the dollar ($) sign).");
        }
        if (r.ReimbursementAmount < 0.01)
        {
            Console.WriteLine("Please enter a greater amount than $0.00.");
        }
        else if (r.ReimbursementAmount  > 5000)
        {
            Console.WriteLine("Please contact our Human Resources department for assistance with this issue.");
        }
        else
        {
            Console.WriteLine("Thank you for your submission.");
        };

/* 
Recording r.Reimbursement(double) amount in a string so that any recorded trailing zeroes will be shown to the user.
We are dealing with money after all, so it's important to account for every penny.
*/
        string amountString = r.ReimbursementAmount.ToString("0.00");

// Confirm the User's input using string interpolation, I store the User's input values into new variables and reference them.
        string confirmation = $"You have requested ${amountString} for reimbursement type {r.ReimbursementTypeId}.";

        Console.WriteLine(confirmation);

        Console.WriteLine($"Thank you, {e.FullName}.\nA confirmation email will be sent momentarily to {e.Email}\nPlease give our system time to process your request.");
        
        }
    }//EndOfClass
}//EndOfNamespace