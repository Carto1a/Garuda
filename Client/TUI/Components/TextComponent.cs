namespace Client.TUI.Components;
public class TextComponent
: BaseComponent
{
    public string? Text { get; private set; }

    public TextComponent(
        string text,
        int top,
        int left,
        int width,
        int height)
    {
        Text = text;
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
        Height = 1;
    }

    public TextComponent(string text)
    {
        Text = text;
    }

    public void Update(string text)
    {
        Modified = true;
        Text = text;
    }

    public override void Render()
    {
        if (Left == null || Top == null)
        {
            return;
        }

        Console.SetCursorPosition((int)Left, (int)Top);
        Console.Write(Text);
        /* Console.SetCursorPosition(Left, Top); */
        /* if (Value == null) */
        /* { */
        /*     Value = Default; */
        /* } */
        /* Console.Write(Value); */
    }
}
