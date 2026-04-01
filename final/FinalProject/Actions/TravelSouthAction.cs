public class TravelSouthAction : AbstractAction
{
    public TravelSouthAction() : base("s", "Travel South") { }

    public override bool CanDoAction(Player player)
    {
        return player.Location.South != null;
    }

    public override void DoAction(Player player)
    {
        player.Travel(player.Location.South);
        Console.WriteLine($"You travel south to the {player.Location.Terrain}.");
        if (player.Location.ObstacleType != null)
            Console.WriteLine($"You see: {player.Location.ObstacleType.Name}. {player.Location.ObstacleType.Description}");
        if (player.Location.HasItem())
            Console.WriteLine($"There is an item here: {player.Location.Item}");
    }
}
