using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> userNumbers = new List<int>();
        int answer;

        Console.WriteLine("Enter a list of numbers WTIH atleast one negative number; type 0 when finished.");
        Console.Write("Enter a number: ");
        string userInput = Console.ReadLine();
        answer = int.Parse(userInput);
        do
        {
            if (answer != 0)
            {
               userNumbers.Add(answer);
            }
            Console.Write("Enter a number: ");
            userInput = Console.ReadLine();
            answer = int.Parse(userInput);

        }while (answer != 0);
        {
            double average = userNumbers.Average();
            int max = userNumbers.Max();
            int closestPositive = int.MaxValue;

            foreach (int i in userNumbers)
            {
                if (i > 0 && i < closestPositive)
                {
                    closestPositive = i;
                }
            }
            
            Console.WriteLine($"Your average is: {average}.");
            Console.WriteLine($"The largest number is: {max}.");
            Console.WriteLine($"The smalles positive number is: {closestPositive}.");
        }
    }
}