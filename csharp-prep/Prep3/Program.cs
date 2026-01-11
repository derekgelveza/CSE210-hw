using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int luckyNumber = randomGenerator.Next(1, 100);
        int userGuess;


        do
        {
            Console.Write("What is your magic number? "); 
            string userResponse = Console.ReadLine();
            userGuess = int.Parse(userResponse);

            if (userGuess > luckyNumber)
            {
                Console.WriteLine("lower");
            }
            else if (userGuess < luckyNumber)
            {
                Console.WriteLine("higher");
            }
        } while (userGuess != luckyNumber);
        Console.WriteLine("You guessed it!");



        
        

        


    }
}