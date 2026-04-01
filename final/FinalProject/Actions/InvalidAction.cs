public class InvalidAction : AbstractAction
{
    public InvalidAction() : base("", "Invalid Action") { }

    public override bool CanDoAction(Player player)
    {
        return true;
    }

    public override void DoAction(Player player)
    {
        Console.WriteLine("That is not a valid action. Please try again.");
    }

    public override bool ValidKey(string test)
    {
        return true;
    }
}
