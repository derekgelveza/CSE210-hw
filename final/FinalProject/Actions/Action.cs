public interface Action
{
    bool CanDoAction(Player player);
    void DoAction(Player player);
    string GetActionDescription();
    string GetKey();
    bool ValidKey(string test);
}
