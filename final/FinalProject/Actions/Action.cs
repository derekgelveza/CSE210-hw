public interface IAction
{
    bool CanDoAction(Player player);
    void DoAction(Player player);
    string GetActionDescription();
    bool ValidKey(string test);
}
