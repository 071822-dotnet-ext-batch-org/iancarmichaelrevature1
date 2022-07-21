/*This is a simple 2-Player game. Player One sets a number between 1-100 and Player Two has to guess.
The console hides Player One's answer so, so long as P2 doesn't look, it's fair.. (ish).*/

using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int airshipHealth = 10;
        int cityHealth = 12;
        int roundNumber = 1;

        int distanceToCity = PromptForNumber("Oh, Great Destroyer of Hello World(Player 1,) how far away from the city do you want to station the airship?");

        Console.Clear();

        ColoredWriteLine("Defender General of Hello World City(Player 2,) it is your turn.", ConsoleColor.DarkGreen);

        while (cityHealth > 0 && airshipHealth > 0)
        {
            ColoredWriteLine("-----------------------------------------------------------------------------------------------------", ConsoleColor.White);
            ColoredWriteLine($"STATUS: Round: {roundNumber} City: {cityHealth} / 12 Airship: {airshipHealth} / 10", ConsoleColor.White);
            int expectedDamage = ComputeExpectedDamage(roundNumber);

            Console.WriteLine($"The cannon is expected to deal {expectedDamage} damage this round.");
            int targetRange = PromptForNumber("Defender General of the Hello World City, enter the desired canon range: ");

            DisplayAttackResult(targetRange, distanceToCity);

            if (targetRange == distanceToCity)
                airshipHealth -= expectedDamage;

            if (airshipHealth > 0) cityHealth--;

            roundNumber++;
        }

        if (airshipHealth <= 0)
            ColoredWriteLine("The airship has been destroyed! The City of Hello World has been saved! Hello World!!!", ConsoleColor.Green);
        else
            ColoredWriteLine("The City of Hello World has been destroyed! Good-bye World!", ConsoleColor.Red);

        void ColoredWriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        void DisplayAttackResult(int target, int actual)
        {
            if (target == actual) ColoredWriteLine("That round was a DIRECT HIT!", ConsoleColor.Blue);
            if (target < actual) ColoredWriteLine("That round FELL SHORT of the target.", ConsoleColor.Cyan);
            if (target > actual) ColoredWriteLine("That round OVERSHOT the target.", ConsoleColor.DarkBlue);
        }

        int ComputeExpectedDamage(int round)
        {
            bool isMultipleOfFive = round % 5 == 0;
            bool isMultipleOfThree = round % 3 == 0;
            if (isMultipleOfFive && isMultipleOfThree) return 10;
            if (isMultipleOfFive || isMultipleOfThree) return 3;
            return 1;
        }

        int PromptForNumber(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            return Convert.ToInt32(Console.ReadLine());
        }

        Console.ReadLine();
    }
}