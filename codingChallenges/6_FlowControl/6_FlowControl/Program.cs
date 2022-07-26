﻿



using System;

namespace _6_FlowControl
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// This method gets a valid temperature between -40 asnd 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
// throw new NotImplementedException($"GetValidTemperature() has not been implemented.");
            int temp = 0; // placing outside of scope
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter a temperature between -40 and 135 degrees Fahrenheit: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out temp))
                {
                    if (temp >= -40 && temp <= 135)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid temperature. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid temperature. Please try again.");
                }
            }
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console 
        /// based on 20 degree increments starting at -20 and ending at 135 
        /// n < -20, Console.Write("hella cold");
        /// -20 <= n < 0, Console.Write("pretty cold");
        ///  0 <= n < 20, Console.Write("cold");
        /// 20 <= n < 40, Console.Write("thawed out");
        /// 40 <= n < 60, Console.Write("feels like Autumn");
        /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
        /// 80 <= n < 90, Console.Write("niiice");
        /// 90 <= n < 100, Console.Write("hella hot");
        /// 100 <= n < 135, Console.Write("hottest");
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
// throw new NotImplementedException($"GiveActivityAdvice() has not been implemented.");
// experimenting with the switch statement instead of massive else if statements.
            switch (temp)
            {
                case int n when (n < -20):
                    Console.WriteLine("hella cold");
                    break;
                case int n when (n < 0):
                    Console.WriteLine("pretty cold");
                    break;
                case int n when (n < 20):
                    Console.WriteLine("cold");
                    break;
                case int n when (n < 40):
                    Console.WriteLine("thawed out");
                    break;
                case int n when (n < 60):
                    Console.WriteLine("feels like Autumn");
                    break;
                case int n when (n < 80):
                    Console.WriteLine("perfect outdoor workout temperature");
                    break;
                case int n when (n < 90):
                    Console.WriteLine("niiice");
                    break;
                case int n when (n < 100):
                    Console.WriteLine("hella hot");
                    break;
                case int n when (n < 135):
                    Console.WriteLine("hottest");
                    break;
                default:
                    Console.WriteLine("Invalid temperature. Please try again.");
                    break;
            }
        }

        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the 
        /// names in the method.
        /// </summary>
        public static void Register()
        {
// store the username and password in the global variables
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
// confirm user's inputs
            Console.WriteLine($"Thank you for registering with us, {username}.");
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true. 
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        static bool Login()
        {
        string username;
        string password;
// set condition for while loop
        bool isValid = false;

        while (!isValid)
        {
            Console.WriteLine("Enter your username: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            password = Console.ReadLine();
// having fun here
            if (username.Length > 5 && password.Length > 5)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again. Usernames and passwords must be at least 6 characters long.");
            }
        }
        return isValid;


            }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given. 
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
// experimenting with ternary operators and string interpolation
            string advice = temp <= 42 ? $"{temp} is too cold!" : temp <= 78 ? $"{temp} is an ok temperature" : $"{temp} is too hot!";
        }
    }//EoP
}//EoN
