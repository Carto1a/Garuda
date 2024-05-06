namespace Client.TUI.Components;
public class TextBoxComponent
: BaseComponent
{
    public string Default { get; set; } = string.Empty;
    public string? Value { get; set; }

    public TextBoxComponent()
    {
        Console.Clear();
    }
}
