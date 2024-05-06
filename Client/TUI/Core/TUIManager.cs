using Client.TUI.Components;

namespace Client.TUI.Core;
public class TUIManager
{
    public TUIRenderer Renderer { get; set; }
    public List<BaseComponent> Components { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public TUIManager()
    {
        Console.WriteLine("TUIManager");
    }
}
