using Client.TUI.Components.Interfaces;

namespace Client.TUI.Components.Containers.Interfaces;
public interface IVerticalContainer
{
    public void MoveComponentLeft(IBaseComponent component, int steps);
    public void MoveComponentRight(IBaseComponent component, int steps);
}
