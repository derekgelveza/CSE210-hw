public class TravelEastAction : AbstractAction
{
    public TravelEastAction() : base("e", "Travel East") { }

    public override bool CanDoAction(Player player)
    {
        return player.Location.East != null;
    }

    public override void DoAction(Player player)
    {
        player.Travel(player.Location.East);
        Console.WriteLine($"You travel east to the {player.Location.Terrain}.");
        if (player.Location.ObstacleType != null)
            Console.WriteLine($"You see: {player.Location.ObstacleType.Name}. {player.Location.ObstacleType.Description}");
        if (player.Location.HasItem())
            Console.WriteLine($"There is an item here: {player.Location.Item}");
    }
}
