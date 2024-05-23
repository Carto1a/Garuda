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


        var keymap0 = new TUIKeymap();
        keymap0.SetKeys("<C-w>lrl");
        keymap0.SetAction(() => _cursor.MoveLeft());
        keymap0.Build();

        var keymap1 = new TUIKeymap("<C-w>lrl",
            () => _cursor.MoveLeft());

        var keymap2 = new TUIKeymap("lrl",
            () => _cursor.MoveLeft());

        var keymap3 = new TUIKeymap("<space>lrl",
            () => _cursor.MoveLeft());
    }

    public void MainLoop()
    {
        while (true)
        {
            _keymap.ReadKeys();
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
