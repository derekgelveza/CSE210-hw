using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int favouriteNumber = PromptUserNumber();
        int userBirthYear;
        PromptUserBirthYear(out userBirthYear);
        int userSquareNumber = SquareNumber(favouriteNumber);

        DisplayResult(userName, userBirthYear, userSquareNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favourite number: ");
        string numberInput = Console.ReadLine();
        int number = int.Parse(numberInput);
        return number;
    }

    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Please enter the year you were born: ");
        string birthdayInput = Console.ReadLine();
        year = int.Parse(birthdayInput);
    }
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    static void DisplayResult(string userName, int userBirthYear,  int userSquareNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {userSquareNumber} ");
        Console.WriteLine($"{userName}, you will turn {2026 - userBirthYear} this year.");
    }
}