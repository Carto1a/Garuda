namespace TermUI.Core;
public class TUICursor
{
    public TUICursor() { }

    public int CursorLeft { get; set; }
    public int CursorTop { get; set; }

    public bool Moved { get; set; }

    public void Move()
    {
        if (!Moved)
            return;

        Moved = false;
        Console.SetCursorPosition(CursorLeft, CursorTop);
    }

    public void Update()
    {
        CursorLeft = Console.CursorLeft;
        CursorTop = Console.CursorTop;
    }

    public void MoveUp()
    {
        if (CursorTop <= 0)
            return;

        CursorTop--;
        Moved = true;
    }

    public void MoveDown()
    {
        var height = Console.WindowHeight;
        if (CursorTop >= height - 1)
            return;

        CursorTop++;
        Moved = true;
    }

    public void MoveLeft()
    {
        if (CursorLeft <= 0)
            return;

        CursorLeft--;
        Moved = true;
    }

    public void MoveRight()
    {
        var width = Console.WindowWidth;
        if (CursorLeft >= width - 1)
            return;

        CursorLeft++;
        Moved = true;
    }
}
