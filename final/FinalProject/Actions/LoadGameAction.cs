public class LoadGameAction : AbstractAction
{
    private readonly GameMap _gameMap;

    public LoadGameAction(GameMap gameMap) : base("load", "Load Game")
    {
        _gameMap = gameMap;
    }

    public override bool CanDoAction(Player player)
    {
        return File.Exists("savegame.txt");
    }

    public override void DoAction(Player player)
    {
        string[] lines = File.ReadAllLines("savegame.txt");

        if (lines.Length == 0)
        {
            Console.WriteLine("Save file is empty.");
            return;
        }

        int tileIndex = int.Parse(lines[0]);
        player.Location = _gameMap.GameTiles[tileIndex];

        player.Inventory.Clear();
        for (int i = 1; i < lines.Length; i++)
        {
            player.Inventory.Add(new Item(lines[i], ""));
        }

        Console.WriteLine("Game loaded.");
        Console.WriteLine($"You are at the {player.Location.Terrain}.");
    }
}
