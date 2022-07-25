using System;

namespace RPSConsole2
{
    class Program
    {
        static void Main(string[] args)
        {

            //create an instance of a Player
            Player p1 = new Player();
            p1.Fname = "Ian";
            p1.Lname = "Carmichael";
            p1.myDoB = new DateTime(1990, 05, 08);

            Console.WriteLine($"The player's name is {p1.Fname} {p1.Lname} and his birthdau is {p1.myDoB.ToShortDateString()}");
            p1.SetAge(109);
            Console.WriteLine("The player's age is {p1.getAge}");
            p1.Wins = 1;
            int wins = p1.Wins;

            Console.WriteLine($"{p1.Fname} has {p1.Wins}.");




//create some players




        void ColoredWriteLine(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
            }

// Introduction
            ColoredWriteLine("Welcome to Rock Paper Scissors!\n", ConsoleColor.White);

// Start the game by pressing ENTER
            ColoredWriteLine("BEST TWO OUT OF THREE.\nTHE FIRST TO WIN TWO ROUNDS IS THE WINNER!", ConsoleColor.Red);
            ColoredWriteLine("Press ENTER to start the game.", ConsoleColor.Yellow);
            Console.ReadLine();

                var maxLength = 15;
                int computerChoice = 0;
                int player1Choice = 0;
                string player1Name = "";
                string computerName = ""; 
                string player1ChoiceStr = "";
                bool successfulConversion = false;
                bool isTie = true;
                string playAgain = "";

// The Random class gets us a pseudorandom decimal between 0 and 1.
            Random rand = new Random();

// Get the users name
            ColoredWriteLine("What's your name? Please use a name smaller than 16 characters.", ConsoleColor.Cyan);
            player1Name = Console.ReadLine();
            if (player1Name.Length > maxLength)
            {
            ColoredWriteLine("Sorry, that name is too long. Please use a name with 15 letters or less.", ConsoleColor.Red);
            return;
            }

// Have the user name the Computer
            ColoredWriteLine("What would you like to name your opponent? Please use a name smaller than 16 characters.", ConsoleColor.Red);
            computerName = Console.ReadLine();
            if (computerName.Length > maxLength)
            {
            ColoredWriteLine("Sorry, that name is too long. Please use a name with 15 letters or less.", ConsoleColor.Red);
            return;
            }
myGoTo:
            int player1Wins = 0;
            int computerWins = 0;
            int numberOfTies = 0;
            ColoredWriteLine($"Welcome to Rock Paper Scissor, {player1Name}!", ConsoleColor.Cyan);

// This loop is for each beginning of a game.
                while(true)
                {

// While loop to keep prompting for choices to satisfy tie-breaker
                    while (isTie)
                    {

// Get the user's choice
                        ColoredWriteLine("Please enter... \n\t1 for Rock.\n\t2 for Paper.\n\t3 for Scissor.", ConsoleColor.Yellow);
                        player1ChoiceStr = Console.ReadLine();

//REMEMBER TO VALIDATE USER INPUT
                        successfulConversion = Int32.TryParse(player1ChoiceStr, out player1Choice);
                        ColoredWriteLine($"The number you inputted was\n{player1Choice}", ConsoleColor.Green);

// Get the computer's randome choice
                        computerChoice = (rand.Next(1000) % 3) + 1;
                        ColoredWriteLine($"The number {computerName} inputted was:\n{computerChoice}", ConsoleColor.Red);

// Evaluate the choices to determine the winner
                        if(player1Choice == computerChoice)
                        {
//tell the user the round resulted in a tie and loop to reprompt
                                numberOfTies++; // ++ increments the int by exactly 1.
                                ColoredWriteLine($"This round was a tie!\nThere's been {numberOfTies} so far\nLet's try again, shall we?", ConsoleColor.Blue);
                        }
                        else if(player1Choice == 1 && computerChoice == 3 || 
                                player1Choice == 2 && computerChoice == 1 ||
                                player1Choice == 3 && computerChoice == 2)
                        {// If the User wins
                                ColoredWriteLine($"Congratualations, {player1Name}, you've won this round.", ConsoleColor.Green);
                                player1Wins++;
                                ColoredWriteLine($"You have {player1Wins} total wins.",ConsoleColor.Green);
                                isTie = false;
                                // player1Wins += 1;
                                // player1Wins = player1Wins +1; // these other methods give you the option of incrementing by more than 1.
                        } 
                        else
                        {// If the Computer wins
                                computerWins++;
                                isTie = false;
                                ColoredWriteLine($"I'm sorry {player1Name}, but {computerName} has won this round.", ConsoleColor.Red);
                                ColoredWriteLine($"{computerName} has {computerWins} total wins.",ConsoleColor.Red);
                        }
                    }

                    if(player1Wins > 1 || computerWins > 1)
                {
                            ColoredWriteLine($"The Maximum number of rounds has been reached.", ConsoleColor.Gray);
                            ColoredWriteLine($"You had {player1Wins} wins.", ConsoleColor.Green);
                            ColoredWriteLine($"{computerName} had {computerWins} wins.", ConsoleColor.Red);
                            ColoredWriteLine($"Hey {player1Name}, would you like to play again?\n\tEnter 'Y' to play again.\n\t'N' to quit the program.", ConsoleColor.Yellow);
                            playAgain = Console.ReadLine();

                    if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
                    {
                            ColoredWriteLine($"Taking it from the top!", ConsoleColor.DarkYellow);
                            isTie = true;
                            goto myGoTo;

                    }
                    else
                    {
                            ColoredWriteLine($"Sorry to see you go. Catch you next time!", ConsoleColor.White);
                    break;
                    }
                }

                            ColoredWriteLine($"Hey {player1Name}, would you like to play again?\n\tEnter 'Y' to play again.\n\t'N' to quit the program.", ConsoleColor.Yellow);
                            playAgain = Console.ReadLine();

                    if (String.Equals("Y", playAgain, StringComparison.OrdinalIgnoreCase))
                    {
                            ColoredWriteLine($"Here we go again!", ConsoleColor.DarkYellow);
                    isTie = true;
                    }
                    else
                    {
                            ColoredWriteLine($"Sorry to see you go. Catch you next time!", ConsoleColor.White);
                    break;
                    }


            }
        }
    }
}

//**FROM>>>REMEMBER TO VALIDATE USER INPUT
//ALTERNATIVE METHOD:
/*THIS IS CALLED COMPOSITE FORMATTING
        try
        {
            player1Choice = Int32.Parse(player1ChoiceStr);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("The parse method failed becasue {0}",ex.Message, player1Choice, player1Name);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"The parse method failed because {ex.Message}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"The parse method failed because {ex.Message}");
        }
THIS IS CALLED COMPOSITE FORMATTING*/

//continue;// Ends the current loop and immediately starts the next iteration of the same loop.