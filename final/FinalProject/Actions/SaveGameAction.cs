public class SaveGameAction : AbstractAction
{
    private readonly GameMap _gameMap;

    public SaveGameAction(GameMap gameMap) : base("save", "Save Game")
    {
        _gameMap = gameMap;
    }

    public override bool CanDoAction(Player player)
    {
        return true;
    }

    public override void DoAction(Player player)
    {
        int tileIndex = -1;
        GameTile[] tiles = _gameMap.GameTiles;

        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == player.Location)
            {
                tileIndex = i;
                break;
            }
        }

        List<string> lines = new List<string>();
        lines.Add(tileIndex.ToString());

        foreach (Item item in player.Inventory)
        {
            lines.Add(item.Name);
        }

        File.WriteAllLines("savegame.txt", lines);
        Console.WriteLine("Game saved.");
    }
}
