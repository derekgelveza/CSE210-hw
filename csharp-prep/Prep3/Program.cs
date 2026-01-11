using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int userGuess;
        string answer;

  

        do
        {

            int luckyNumber = randomGenerator.Next(1, 100);
            int attempts = 0;

            do
            {
                Console.Write("What is your magic number? "); 
                string userResponse = Console.ReadLine();
                userGuess = int.Parse(userResponse);
                attempts++;

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
            Console.WriteLine($"It took you {attempts} tries.");

            Console.WriteLine("Would you like to play again?");
            answer = Console.ReadLine();

        } while (answer == "yes" || answer == "Yes");
        if (answer == "no" || answer == "No")
        {
            Console.Write("Ok, have a good day!");
        }
        



        
        

        


    }
}