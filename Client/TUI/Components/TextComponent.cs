namespace Client.TUI.Components;
public class TextComponent
: BaseComponent
{
    private string? _text { get; set; }
    public string? Text
    {
        get => _text;
        set
        {
            var temp = value ?? string.Empty;
            _text = temp;
            MaxLastLength = temp.Length;
            Modified = true;
        }
    }
    public int MaxLastLength { get; set; } = 0;

    public TextComponent(
        string text,
        int top,
        int left,
        int width,
        int height)
    {
        Text = text;
        MaxLastLength = text.Length;
        Top = top;
        Left = left;
        Width = width;
        Height = height;
    }

    public TextComponent(
        string text,
        int top,
        int left)
    {
        Top = top;
        Left = left;
        Text = text;
        Width = text.Length;
        MaxLastLength = text.Length;
        Height = 1;
    }

    public TextComponent(string text)
    {
        Text = text;
        MaxLastLength = text.Length;
    }

    public void Update(string text)
    {
        Modified = true;
        Text = text;
        MaxLastLength = text.Length;
    }

    public override void Render()
    {
        if (Left == null || Top == null)
        {
            return;
        }

        Console.SetCursorPosition((int)Left, (int)Top);
        Console.Write(_text?.PadRight(MaxLastLength + 1, ' '));
    }
}
