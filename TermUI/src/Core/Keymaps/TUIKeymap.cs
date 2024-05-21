namespace TermUI.Core.Keymaps;
public class TUIKeymap
{
    public ConsoleKey Key { get; set; }
    public Action Action { get; set; }

    public TUIKeymap(ConsoleKey key, Action action)
    {
        Key = key;
        Action = action;
    }
}
