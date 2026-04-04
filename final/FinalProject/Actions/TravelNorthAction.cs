public class TravelNorthAction : AbstractAction
{
    public TravelNorthAction() : base("n", "Travel North") { }

    public override bool CanDoAction(Player player)
    {
        return player.Location.North != null;
    }

    public override void DoAction(Player player)
    {
        player.Travel(player.Location.North);
        Console.WriteLine($"You travel north to the {player.Location.Terrain}.");
    }
}
