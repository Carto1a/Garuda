namespace Client.TUI.Components.Interfaces;
public interface IBaseComponent
{
    public int? Top { get; set; }
    public int? Left { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    void DeclareSize(int width, int height);
    void Render();
}
