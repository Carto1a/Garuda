namespace TermUI.Core.Keymaps;
public class TUIKeymap
{
    // <C-w>lrl
    private string Keys { get; set; }
    private Action Action { get; set; }
    private string Description { get; set; }
    private bool CanCount { get; set; } = false;
    private bool CanObject { get; set; } = false;

    public TUIKeymap(string keys, Action action)
    {
        Keys = keys;
        Action = action;
    }

    public TUIKeymap() { }

    public void SetAction(Action action)
    {
        Action = action;
    }

    public void SetKeys(string keys)
    {
        Keys = keys;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetModifiers(bool canCount, bool canObject)
    {
        CanCount = canCount;
        CanObject = canObject;
    }

    public void Build()
    { }
}
