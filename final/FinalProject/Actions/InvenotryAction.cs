public class InventoryAction : AbstractAction
{
    public InventoryAction() : base("i", "Show Inventory") { }

    public override bool CanDoAction(Player player)
    {
        return true;
    }

    public override void DoAction(Player player)
    {
        player.ShowInventory();
    }
}
