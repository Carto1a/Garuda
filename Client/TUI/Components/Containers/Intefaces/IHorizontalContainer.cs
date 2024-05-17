using Client.TUI.Components.Interfaces;

namespace Client.TUI.Components.Containers.Interfaces;
public interface IHorizontalContainer
{
    public void MoveComponentUp(IBaseComponent component, int steps);
    public void MoveComponentDown(IBaseComponent component, int steps);
}
