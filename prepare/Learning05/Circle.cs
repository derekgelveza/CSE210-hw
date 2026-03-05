using System;

class Circle : Shape
{
    
    private double _radius;

    public Circle(string Color, double Radius) : base(Color)
    {
        _radius = Radius;
    }

    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }


}