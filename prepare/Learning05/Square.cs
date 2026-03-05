using System;

class Square : Shape
{
    private double _side;

    public Square(string Color, double Side) : base(Color)
    {

        _side = Side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}