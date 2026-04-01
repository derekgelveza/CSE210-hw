public class GetItemAction : AbstractAction
{
    public GetItemAction() : base("g", "Get Item") { }

    public override bool CanDoAction(Player player)
    {
        return player.Location.CanGetItem();
    }

    public override void DoAction(Player player)
    {
        player.GetItem();
    }
}
