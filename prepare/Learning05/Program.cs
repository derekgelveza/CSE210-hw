using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        
        List<Shape> shapes = new List<Shape>();
        
        Square square = new Square("blue", 2);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("red", 2, 5); 
        shapes.Add(rectangle);

        Circle circle = new Circle("yellow", 10);
        shapes.Add(circle);


        foreach (Shape shape in shapes)
        {
            double area = shape.GetArea();

            string color = shape.Color;

            Console.WriteLine($"The shape is {color} and has an area of {area}");

        }
    }
}