using System;

/*This is just the planning phase of the program.*/

//v0.001 = Initial Birth of the program. (07/27/2022)

// PROJECT ONE: Expense reimbursement system

namespace ExpenseReimbursementSystem

{
    class Program
    {
        static void Main(string[] args)
        {

// Console prompts the User to input employee ID
        Console.WriteLine("Please enter your employee ID: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

// Console prompts the User to input employee first name
        Console.WriteLine("Please enter your first name: ");
        string firstName = Console.ReadLine();
            
// Console prompts the User to input employee last name
        Console.WriteLine("Please enter your last name: ");
        string lastName = Console.ReadLine();

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

// Console prompts the User to input the amount of reimbursement they are requesting
        Console.WriteLine("Please enter the amount of reimbursement you are requesting: ");
// Convert the User's input to an integer
        int reimbursementAmount = Convert.ToInt32(Console.ReadLine());

// Console prompts the User to input the type of reimbursement they are requesting from the enum I made in ReimbursementTypes.cs
        Console.WriteLine("Please enter the type of reimbursement you are requesting: ");
        Console.WriteLine("1. Lodging");
        Console.WriteLine("2. Travel");
        Console.WriteLine("3. Food");
        Console.WriteLine("4. Other");

// Convert the user input to an integer
        int ReimbursementTypeId = Convert.ToInt32(Console.ReadLine());

        }
    }
}