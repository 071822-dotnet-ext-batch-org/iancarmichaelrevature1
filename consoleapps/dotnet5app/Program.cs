/*This is a simple 2-Player game. Player One sets a number between 1-100 and Player Two has to guess.
The console hides Player One's answer so, so long as P2 doesn't look, it's fair.. (ish).*/

using System;

int manticoreHealth = 10;
int cityHealth = 12;
int roundNumber = 1;

int distanceToCity = PromptForNumber("Oh, Great Uncoded One(Player 1,) how far away from the city do you want to station the Manticore?");

Console.Clear();

ColoredWriteLine("Defender General of Consolas(Player 2,) it is your turn.", ConsoleColor.DarkGreen);

while (cityHealth > 0 && manticoreHealth > 0)
{
    ColoredWriteLine("-----------------------------------------------------------------------------------------------------", ConsoleColor.White);
    ColoredWriteLine($"STATUS: Round: {roundNumber} City: {cityHealth} / 15 Manticore: {manticoreHealth} / 10", ConsoleColor.White);
    int expectedDamage = ComputeExpectedDamage(roundNumber);

    Console.WriteLine($"The cannon is expected to deal {expectedDamage} damage this round.");
    int targetRange = PromptForNumber("Defender General of Consolas, enter the desired canon range: ");

    DisplayAttackResult(targetRange, distanceToCity);

    if (targetRange == distanceToCity)
        manticoreHealth -= expectedDamage;

    if (manticoreHealth > 0) cityHealth--;

    roundNumber++;
}

if (manticoreHealth <= 0)
    ColoredWriteLine("The Manticore has been destroyed! The City of Consolas has been saved!", ConsoleColor.Green);
else
    ColoredWriteLine("The City of Consolas has been destroyed! The Uncoded One has defeated you!", ConsoleColor.Red);

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