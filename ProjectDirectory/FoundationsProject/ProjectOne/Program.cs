using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*This is just the planning phase of the program.*/

//Update: v0.005: 07.31.2022;
/*         Made a new method to call TryParse and recursively loop
           when the user inputs any letter during Employee ID input
           process. Inadvertantly created a bug(?) where the user must
           input a value again to proceed with the program, but I've 
           accounted for it by using prompts to the user. Almost seems 
           like an intentional layer of validation for user input.
           Definitely keeping it for now.
           TODO: Figure out how to refactor this code to bring it
                 more in line with the principles of OOP.
*/
//v0.001:  Initial Birth of the program. 07.27.2022;
/*v0.002:  Revised the blueprint of program to exclude redudant variables. 07.27.2022;
           Also: added some simple dialogue box functionality to Program.cs
           Also: Experimented with Properties and out parameters, I'll have 
                 a few questions going into class tomorrow~     
*/
/*v0.003:  Lessons learned today about namespaces and classes: 
           namespace was previously ExpenseReimbursementSystem. 
           My neural pathways are always under construction.
           Also: I instanciated the Employee class in Program.cs
           Also: I parameterized a constructor for Employee
                 and reorganized my getters and setters.        
*/
//v0.004:  Lots of small refactors in Program.cs. 07.30.2022; 
/*         Also: I found a way to display trailing zeroes.
                 (This is important since we're dealing
                 with currency. Money ain't no game.)
           TODO: Use Exception Handling to catch errors.
                 (My dreams are haunted by these errors.)      
           TODO: Decide on either/or a List and/or Dictionary
                 to store data and mimic an SQL database.   
.:Continued later, the same day: 07.30.2022;
           Made the realization that ReimbursementTypes.cs
           isn't even being utilized by the program.            
           Also: I made a directory at the end of the program.
           TODO: Use it, or lose it, enum.        
.:Continued later, the same day: 07.30.2022;
           The noobish else-if monstrosity at the bottom is
           now a proper switch statement.
*/

// PROJECT ONE: Expense reimbursement system
namespace ProjectOne

{
    class Program
    {
        static void Main(string[] args)
        {
        Console.Clear();
        Employee e = new Employee();
        Reimbursement r = new Reimbursement();
        int employeeId = 0;

            static void IdTryParse(string input, out int output)
            {
                if (int.TryParse(input, out output))
                {
                    Console.Clear();
                    Console.WriteLine($"Thank you, \"{output}\" is a valid Employee ID.\nPlease enter it one more time, just to confirm your input.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Sorry, but \"{input}\" is not a valid Employee ID.\n\nYou must enter either a NUMBER, or series of NUMBERS.");
                    IdTryParse(Console.ReadLine(), out output);
                }
            }

Restart1:
        Console.WriteLine("Welcome to Revature's Employee Expense Reimbursement System.\nPlease enter your employee ID: ");
        IdTryParse(Console.ReadLine(), out employeeId);
        employeeId = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("You've entered " + employeeId + ".\nThis is your Employee ID number, correct? Yes or No.");
        string employeeIDAnswer = Console.ReadLine();
        // if yes continue and if no, repeat the process
        if (String.Equals("Yes", employeeIDAnswer, StringComparison.OrdinalIgnoreCase))
        {
            Console.Clear();
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
        Console.Clear();
        Console.WriteLine("Please enter your last name: ");
        string lastName = Console.ReadLine();

// take both first and last name and combine them into one string
        string fullName = firstName + " " + lastName;

// ask the User if their fullName is correct
        Console.Clear();
        Console.WriteLine("Is " + fullName + " your full name?");
        string fullNameAnswer = Console.ReadLine();

// if yes continue and if no, repeat the process
        if (String.Equals("Yes", fullNameAnswer, StringComparison.OrdinalIgnoreCase))
        {
            Console.Clear();
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

Restart3:
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
            Console.Clear();
            Console.WriteLine("Thank you, " + e.FullName + ".\n");
            e.Email = email;
        }

Restart4:
// Console prompts the User to input the type of reimbursement they are requesting from the enum I made in ReimbursementTypes.cs
        Console.WriteLine("Please enter the type of reimbursement you are requesting: ");
        Console.WriteLine("1. Food");
        Console.WriteLine("2. Lodging");
        Console.WriteLine("3. Travel");
        Console.WriteLine("4. Other");

// Convert the User's input to an integer
        int reimbursementTypeId = Convert.ToInt32(Console.ReadLine());
        r.ReimbursementTypeId = reimbursementTypeId;
        string otherReimbursement = "";
        string reimbursementString = "";

// if the User input is 1, the program will print out "Food," and ask if this is correct.
        if (reimbursementTypeId == 1)
        {
            Console.Clear();
            reimbursementString = "1 (FOOD)";
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
            Console.Clear();
            reimbursementString = "2 (LODGING)";
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
            Console.Clear();
            reimbursementString = "3 (TRAVEL)";
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
            Console.Clear();
            Console.WriteLine("Other,");
            Console.WriteLine("Is this correct?");

                //if the user input is yes, the program will continue.
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Please specify what type of Reimbursement this is.");
// store user response as a new type of reimbursement
                    otherReimbursement = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"You've indicated this type of reimbursement is for {otherReimbursement}.");
                    Console.WriteLine("Thank you for your submission.");
                    reimbursementString = $"4 (OTHER): {otherReimbursement}";
                            
                }
        }

Restart5:
// Console prompts the User to input the amount of reimbursement they are requesting
        Console.WriteLine("Please enter the amount of reimbursement you are requesting: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        // if the user input is not a numerical value, the program will prompt the user to re-enter the amount of reimbursement
        if (amount.ToString().Any(char.IsLetter))
        {
            Console.WriteLine("Please enter a number. (It may help to omit the dollar ($) sign).");
            goto Restart5;
        }
        else
        {
        Console.WriteLine($"Thank you, {e.FullName}, you've input ${amount}.");
            r.ReimbursementAmount = amount;
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

// Confirm the User's input, and using string interpolation, I reference the User's input values thus far, and give them a chance to correct their input.
        Console.Clear();
        string confirmation = $"You have requested ${amountString} for reimbursement type {reimbursementString}.\n\nIs this amount correct?";

        Console.WriteLine(confirmation);
        string confirmationAnswer = Console.ReadLine();
        string confirmationAnswer2 ="";
        
        if (String.Equals("Yes", confirmationAnswer, StringComparison.OrdinalIgnoreCase))
        {
            Console.Clear();
            string summary = $"Before we continue on to finalizing your reimbursment request, here's the information you've submitted thus far:\nYour full name: {e.FullName}\nYour Employee ID number: {e.EmployeeId}\nYour email address: {e.Email}\nYour reimbursement type: {reimbursementString}\nYour reimbursement amount: ${amountString}\n\nDoes all of this look correct?\n";
            Console.WriteLine(summary);
            confirmationAnswer2 = Console.ReadLine();
        }
        else
        {
            Console.Clear();
            goto Restart5;
        }
        if (String.Equals("Yes", confirmationAnswer2, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"\nThank you, {e.FullName}.\nA confirmation email will be sent momentarily to {e.Email}\nPlease give our system time to process your request.");
        }
        if
        (String.Equals("No", confirmationAnswer2, StringComparison.OrdinalIgnoreCase))
        {
Restart6:
            Console.WriteLine("Please Select where in the process you want to restart.");
            Console.WriteLine("1. Re-enter your Employee ID number.");
            Console.WriteLine("2. Re-enter your full name.");
            Console.WriteLine("3. Re-enter your email address.");
            Console.WriteLine("4. Re-enter your reimbursement type.");
            Console.WriteLine("5. Re-enter your reimbursement amount.");

            int restart = Convert.ToInt32(Console.ReadLine());

// Below is a directory 
//(The previous else-if chain is now a much cleaner and more concise switch statement)
            switch (restart)
            {
                case 1:
                    Console.Clear();
                    goto Restart1;
                case 2:
                    Console.Clear();
                    goto Restart2;
                case 3:
                    Console.Clear();
                    goto Restart3;
                case 4:
                    Console.Clear();
                    goto Restart4;
                case 5:
                    Console.Clear();
                    goto Restart5;
                default:
                    Console.WriteLine("Please enter a number between 1 and 5.");
                    goto Restart6;
            }
        }

        }
      
    }//EndOfClass
}//EndOfNamespace
