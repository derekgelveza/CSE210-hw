using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFraction());
        Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFraction());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFraction());
        Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFraction());
        Console.WriteLine(fraction4.GetDecimalValue());

        Fraction fraction5 = new Fraction();
        Random random = new Random();

        for (int i = 0; i < 20; i++)
        {
            int randomTop = random.Next(1, 11);
            int randomBottom = random.Next(1 , 11);
            fraction5.Top = randomTop;
            fraction5.Bottom = randomBottom;
            Console.Write($"Fraction: {i + 1} ");
            Console.Write($" string: {fraction5.GetFraction()}");
            Console.WriteLine($" Number: {fraction5.GetDecimalValue()}");
        }
    }
}