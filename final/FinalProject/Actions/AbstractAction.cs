public abstract class AbstractAction : IAction
{
    protected string _key;
    protected string _description;

    public AbstractAction(string key, string description)
    {
        _key = key;
        _description = description;
    }

    public abstract bool CanDoAction(Player player);

    public abstract void DoAction(Player player);

    public string GetActionDescription()
    {
        return _description;
    }

    public bool ValidKey(string test)
    {
        return _key.Equals(test, StringComparison.OrdinalIgnoreCase);
    }
}
