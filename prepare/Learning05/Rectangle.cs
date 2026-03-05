using System;

class Rectangle : Shape
{
    
    private double _length;
    private double _width;

    public Rectangle(string Color, double Length, double Width) : base(Color)
    {
        _length = Length;
        _width = Width;
    }


    public override double GetArea()
    {
        return _length * _width;
    }


}