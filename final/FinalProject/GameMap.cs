using System;

public class GameMap
{
    private GameTile[] _gameTiles = new GameTile[9];

    public GameTile[] GameTiles
    {
        set
        {
            _gameTiles = value;
        }
    }

    public void GameMap()
    {
        
    }

}

