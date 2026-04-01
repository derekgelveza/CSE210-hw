public class ShowMapAction : AbstractAction
{
    public ShowMapAction() : base("m", "Show Map") { }

    public override bool CanDoAction(Player player)
    {
        return true;
    }

    public override void DoAction(Player player)
    {
        player.ShowMap();
    }
}
