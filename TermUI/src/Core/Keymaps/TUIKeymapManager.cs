namespace TermUI.Core.Keymaps;
public class TUIKeymapManager
{
    // {count?} {keymap} {count?} {text object}
    private TUICursor _cursor { get; set; }

    private Dictionary<ConsoleKey, Action> Keymaps { get; set; } = new();

    public TUIKeymapManager(TUICursor cursor)
    {
        _cursor = cursor;

        Keymaps.Add(ConsoleKey.UpArrow, () => cursor.MoveUp());
        Keymaps.Add(ConsoleKey.DownArrow, () => cursor.MoveDown());
        Keymaps.Add(ConsoleKey.LeftArrow, () => cursor.MoveLeft());
        Keymaps.Add(ConsoleKey.RightArrow, () => cursor.MoveRight());
    }

    public void SetKeymap(ConsoleKey key, Action action)
    {
        Keymaps[key] = action;
    }

    public void RemoveKeymap(ConsoleKey key)
    {
        Keymaps.Remove(key);
    }

    public void ExecuteKeymap(ConsoleKey key)
    {
        if (Keymaps.ContainsKey(key))
        {
            Keymaps[key]();
        }
    }
}
