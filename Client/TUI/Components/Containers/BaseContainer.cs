namespace Client.TUI.Components.Containers;
public class BaseContainer
: BaseComponent
{
    public bool HasBorder { get; set; }
    public BaseContainer(bool hasBorder = false)
    {
        HasBorder = hasBorder;
    }

    public override void Render()
    {
        throw new NotImplementedException();
    }
}
