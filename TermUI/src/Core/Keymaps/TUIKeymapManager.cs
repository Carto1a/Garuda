namespace TermUI.Core.Keymaps;
public class TUIKeymapManager
{
    // {count?} {keymap} {object}
    // <C-a>fad
    // <C-S-w>
    // <space>
    private TUICursor _cursor { get; set; }
    private System.Threading.Timer _TimeoutKeymap;

    public int TimeoutKeymap { get; set; } = 500;

    private Dictionary<ConsoleKey, Action> Keymaps { get; set; } = new();
    private List<char> _keyModifierCount { get; set; } = new();
    private List<char> _keyPressedObjects { get; set; } = new();
    private List<char> _keyPressed { get; set; } = new();


    private List<TUIKey> _rootkeymaps { get; set; } = new();
    private List<TUIKey> _rootkeymapsladder { get; set; } = new();

    private List<TUIKey> _rootkeymapsctrl { get; set; } = new();
    private List<TUIKey> _rootkeysmapalt { get; set; } = new();

    private bool _canCount { get; set; } = true;

    public TUIKeymapManager(TUICursor cursor)
    {
        _cursor = cursor;

        _TimeoutKeymap = new Timer((e) =>
            ClearKeymapStates(),
        null, Timeout.Infinite, Timeout.Infinite);

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
            var keyChar = key.KeyChar;

            /* var modifier = key.Modifiers; */
            /* var t = key.Key; */

            /* Console.SetCursorPosition(0, 0); */
            /* var bits = Convert.ToString(keyChar, 2); */

            KeyCountModifier(keyChar);
            // tem filhos?
            // termina nele?
            // se sim, executa

            /* Console.Write($"a: {String.Join("", _keyModifierCount)}"); */
            /* Console.Write($"Bits: {bits} | Key: {keyChar} | Modifier: {modifier} | Console: {t}"); */

            if (!_canCount)
                StartTimeoutKeymap();

        }
    }

    public Task ReadKeysAsync()
    {
        return Task.Run(() => ReadKeys());
    }

    private void ClearKeymapStates()
    {
        _canCount = true;
        _keyModifierCount.Clear();
    }

    private void StartTimeoutKeymap()
    {
        _TimeoutKeymap.Change(TimeoutKeymap, Timeout.Infinite);
    }

    public void KeyCountModifier(char key)
    {
        if (_canCount &&
            (key >= '0' && key <= '9'))
        {
            _keyModifierCount.Add(key);
            return;
        }

        _canCount = false;
    }

    public void SetKeymap(TUIKeymap keymap)
    {
        // Parse keys
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
