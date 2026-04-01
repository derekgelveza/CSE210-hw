public class QuitAction : AbstractAction
{
    public QuitAction() : base("q", "Quit Game") { }

    public override bool CanDoAction(Player player)
    {
        return true;
    }

    public override void DoAction(Player player)
    {
        Console.WriteLine("Thanks for playing. Goodbye!");
        Environment.Exit(0);
    }
}
