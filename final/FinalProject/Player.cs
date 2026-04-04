using System.Collections.Generic;

public class Player
{
    private GameTile _location;
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

    private List<Item> _inventory = [];
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

    public void Init(GameMap gameMap)
    {
        _gameMap = gameMap;
        Location = _gameMap.GameTiles[8];
        Location.IsVisited = true;
    }

    public void Travel(GameTile destination)
    {
        if (destination != null)
        {
            Location = destination;
            Location.IsVisited = true;
        }
        else
        {
            Console.WriteLine("You can't travel in that direction.");
        }
    }

    public void ShowInventory()
    {
        if (_inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
            return;
        }

        Console.Write("Your inventory: ");
        foreach (Item item in _inventory)
        {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
    }

    public void GetItem()
    {
        if (!Location.HasItem())
        {
            Console.WriteLine("There is nothing to pick up here.");
            return;
        }

        if (Location.ObstacleType != null)
        {
            Console.WriteLine($"There is an obstacle in the way: {Location.ObstacleType.Name}. {Location.ObstacleType.Description}");
            return;
        }

        Item item = Location.Item!;
        _inventory.Add(item);
        Console.WriteLine($"You picked up: {item}");
        Console.WriteLine(item.Description);
        Location.RemoveItem();
    }

    public void ShowMap()
    {
        _gameMap.ShowMap(Location);
    }
}
