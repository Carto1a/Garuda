namespace TermUI.Core.Keymaps;
public class TUIKeymap
{
    public string Keys { get; set; }
    public Action Action { get; set; }
    public string Description { get; set; }

    public TUIKeymap(string keys, Action action)
    {
        Keys = keys;
        Action = action;
    }
}
