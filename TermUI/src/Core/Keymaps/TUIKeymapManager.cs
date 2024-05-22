namespace TermUI.Core.Keymaps;
public class TUIKeymapManager
{
    // {count?} {keymap} {count?} {object}
    // <C-a>fad
    // <space>
    private TUICursor _cursor { get; set; }

    public uint Timeout { get; set; } = 500;

    private Dictionary<ConsoleKey, Action> Keymaps { get; set; } = new();
    private List<char> _keyModifierCount { get; set; } = new();
    private List<char> _keyPressedObjects { get; set; } = new();
    private List<char> _keyPressed { get; set; } = new();
    private bool _canCount { get; set; } = true;

    public TUIKeymapManager(TUICursor cursor)
    {
        _cursor = cursor;

        Keymaps.Add(ConsoleKey.UpArrow, () => cursor.MoveUp());
        Keymaps.Add(ConsoleKey.DownArrow, () => cursor.MoveDown());
        Keymaps.Add(ConsoleKey.LeftArrow, () => cursor.MoveLeft());
        Keymaps.Add(ConsoleKey.RightArrow, () => cursor.MoveRight());
    }

    public void ReadKeys()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            var modifier = key.Modifiers;
            var keyChar = key.KeyChar;
            var t = key.Key;
            Console.SetCursorPosition(0, 0);
            var bits = Convert.ToString(keyChar, 2);
            KeyCountModifier(keyChar);
            /* Console.Write($"a: {String.Join("", _keyModifierCount)}"); */
            Console.Write($"Bits: {bits} | Key: {keyChar} | Modifier: {modifier} | Console: {t}");
        }
    }

    public Task ReadKeysAsync()
    {
        return Task.Run(() => ReadKeys());
    }

    public void KeyCountModifier(char key)
    {
        // TODO: fazer uma forma melhor
        // no momento, so pegar os numeros do inicio
        if (_canCount &&
            (key >= '0' && key <= '9'))
        {
            _keyModifierCount.Add(key);
            return;
        }

        _canCount = false;
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
