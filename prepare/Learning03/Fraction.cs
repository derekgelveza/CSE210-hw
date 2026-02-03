using System;

class Fraction
{
    private int _top;
    private int _bottom;

    //Constructors
    public Fraction()
    {
        Top = 1;
        Bottom = 1;
    }
    public Fraction (int number)
    {
        Top = number;
        Bottom = 1;
    }
    public Fraction (int top, int bottom)
    {
        this.Top = top;
        this.Bottom = bottom;
    }


    //getters and setters
    public int Top
     {
        get {return _top; }
        set
        {
                _top = value;
        }
   }

   public int Bottom
    {
        get {return _bottom; }
        set
        {
            if (value != 0 )
            {
                _bottom = value;
            } else
            {
                _bottom = 1;
            }
            
        }
    }

    public string GetFraction()
    {
        return  $"{Top} / {Bottom}"; 
    }

    public double GetDecimalValue()
    {
        return (double)Top / (double)Bottom;
    }


}