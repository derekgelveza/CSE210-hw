using System;

public class GameTile
{
    public TerrainType _terrain;

    private GameTile _north;
    private GameTile _south;
    private GameTile _east;
    private GameTile _west;

    private Item _item;
    private bool _isVisited;
    private Obstacle _obstacle;
    public GameTile(TerrainType terrain, Item item, Obstacle obstacle)
    {
        _terrain = terrain;
        _item = item;
        _obstacle = obstacle;
    }
    public TerrainType Terrain {
        get
        {
            return _terrain;
        }
        set
        {
            _terrain = value;
        }
    }

    public GameTile North
    {
        get
        {
            return _north;
        }
        set
        {
            _north = value;
        }
    }

    public GameTile South
    {
        get
        {
            return _south;
        }
        set
        {
            _south = value;
        }
    }

    public GameTile East
    {
        get
        {
            return _east;
        }
        set
        {
            _east = value;
        }
    }

    public GameTile West
    {
        get
        {
            return _west;
        }
        set
        {
            _west = value;
        }
    }

    public Item Item{
        get
        {
            return _item;
        }
        set
        {
            _item = value;
        }
    }

    public bool IsVisited
    {
        get
        {
            return _isVisited;
        }
        set
        {
            _isVisited = value;
        }
    }

    public Obstacle ObstacleType
    {
        get
        {
            return _obstacle;
        }
        set
        {
            _obstacle = value;
        }
    }

    public bool CanGetItem()
    {
        return Item != null && ObstacleType == null;
    }

    public bool HasItem()
    {
        if (Item != null)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void RemoveItem()
    {
        Item = null;
    }

    public string ShowTile()
    {
        return IsVisited ? Terrain.ToString() : "*******";
    }
}