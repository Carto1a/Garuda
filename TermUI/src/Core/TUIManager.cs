using TermUI.Core.Keymaps;

namespace TermUI.Core;
public class TUIManager
{
    public TUICursor _cursor { get; set; }
    public TUIKeymapManager _keymap { get; set; }

    public TextWriter OriginalOut { get; set; } = Console.Out;
    public TextReader OriginalIn { get; set; } = Console.In;

    public int Width { get; set; }
    public int Height { get; set; }
    public int CursorLeft { get; set; }
    public int CursorTop { get; set; }

    public TUIManager()
    {
        // mudar no futuro
        _cursor = new TUICursor();
        _keymap = new TUIKeymapManager(_cursor);
    }

    public void MainLoop()
    {
        while (true)
        {
            var key = Console.ReadKey(true).Key;
            _keymap.ExecuteKeymap(key);
            _cursor.Move();
        }
    }

    public void Initialize()
    {
        Console.Clear();

        Width = Console.WindowWidth;
        Height = Console.WindowHeight;
        CursorLeft = Console.CursorLeft;
        CursorTop = Console.CursorTop;
    }
}
