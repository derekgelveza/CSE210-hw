using System;
using System.Collections;

public class Player
{
    GameTile _location;
    private GameMap _gameMap;

    public GameTile Location
    {
        get
        {
            return _location;
        }
        set
        {
            _location = value;
        }
    }

    public List<Item> _inventory = new List<>();
    public List<Item> Inventory
    {
        get
        {
            return _inventory;
        }
        set
        {
            _inventory = value;
        }
    }

    public void Init(GameMap _gameMap)
    {
        this._gameMap = _gameMap;
        this.Location = _gameMap.GameTiles()[4];
        Location.IsVisited = true;
    }

    public void ShowInventory()
    {
        Console.Write("Your inventory: ");

        foreach (Item item in Inventory)
        {
            Console.Write(item + ", ");
        }

        Console.WriteLine();
    }

    public void PickUpItem()
    {
        if (Location.HasItem())
        {
            Item item = Location.Item;

            Inventory.Add(item);
            Console.WriteLine(item + " was added to inventory");
            Location.RemoveItem();
        } else
        {
            Console.WriteLine("There is no item here to get");
        }
    }

    public void ShowMap()
    {
        _gameMap.ShowMap(Location);
    }
   
}
