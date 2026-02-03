using System;

class Fraction
{
    private int _top;
    private int _bottom;

    //Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction (int _top)
    {
        this._top = _top;
        this._bottom = 5;
    }
    public Fraction (int _top, int _bottom)
    {
        this._top = _top;
        this._bottom = _bottom;
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
        return  $"{_top} / {_bottom}"; 
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }


}