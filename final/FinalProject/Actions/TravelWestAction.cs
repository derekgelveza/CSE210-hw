public class TravelWestAction : AbstractAction
{
    public TravelWestAction() : base("w", "Travel West") { }

    public override bool CanDoAction(Player player)
    {
        return player.Location.West != null;
    }

    public override void DoAction(Player player)
    {
        player.Travel(player.Location.West);
        Console.WriteLine($"You travel west to the {player.Location.Terrain}.");
        if (player.Location.ObstacleType != null)
            Console.WriteLine($"You see: {player.Location.ObstacleType.Name}. {player.Location.ObstacleType.Description}");
        if (player.Location.HasItem())
            Console.WriteLine($"There is an item here: {player.Location.Item}");
    }
}
