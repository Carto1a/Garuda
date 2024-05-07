using Client.TUI.Components.Interfaces;

namespace Client.TUI.Components;
public abstract class BaseComponent
: IBaseComponentRender
{
    public int? Top { get; set; }
    public int? Left { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool Modified { get; protected set; }

    public void Unmodified() => Modified = false;

    public abstract void Render();
    /* public BaseComponent() */
    /* { */
    /*     Children = new List<BaseComponent>(); */
    /* } */
}
