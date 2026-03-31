using System;

public class Item
{
    
    private string _name;
    private string _description;

    public static Item KING_ARTHUR_SWORD;
    public static Item AXE;

    public Item (string name, string description)
    {
        Name = name;
        Description = description;
    }
    public override string ToString()
    {
        return _name;
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
}