using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? Please only input the number. DO NOT ADD letters or special symbols: ");
        string userInput = Console.ReadLine();
        int userGrade = int.Parse(userInput);
        
        string letterGrade = "";
        //Let's system know what grade user recieved
        if (userGrade >= 90)
        {
            letterGrade = "A";
        }
        else if (userGrade >= 80)
        {
            letterGrade = "B";
        }
        else if (userGrade >= 70)
        {
            letterGrade = "C";
        }
        else if (userGrade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        //modifer for + or -
        string modifer = "";

        int lastDigit = userGrade % 10;
        
        if(lastDigit >= 7)
        {
            modifer = "+";
        }
        else if(lastDigit <= 3)
        {
            modifer = "-";
        }

        if (letterGrade == "A" && modifer == "+")
        {
            modifer = "";
        }
        if (letterGrade == "F")
        {
            modifer = "";
        }
        

        //add modifer to the grade
        string finalGrade = letterGrade + modifer;


        //This ensures proper grammar when informing the user of their overall grade. I'm aware this is not part of the assignment but the grammar issue bothers me, sorry
        if (letterGrade == "A")
        {
            Console.WriteLine($"Your overall grade is an {finalGrade}");
        }
        else if (letterGrade == "F")
        {
            Console.WriteLine($"Your overall grade is an {finalGrade}");
        }
        else
        {
            Console.WriteLine($"Your overall grade is a {finalGrade}");
        }

        //Lets the user know if they passed
        if (userGrade >= 70)
        {
            Console.Write("You have passed the class. Congrats!");
        }
        else
        {
            Console.WriteLine("You have failed the class. Please take the class again, you will do much better!");
        }

    }
}