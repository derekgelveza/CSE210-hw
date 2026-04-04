using System;

public class Obstacle
{
    private string _name;
    private Item _required;
    private string _description;

    public Obstacle(string name, string description, Item required)
    {
        _name = name;
        _required = required;
        _description = description;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }

        public Item Required
    {
        get
        {
            return _required;
        }
        set
        {
            _required = value;
        }
    }
}