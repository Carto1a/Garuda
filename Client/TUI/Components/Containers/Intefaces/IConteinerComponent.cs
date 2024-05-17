using Client.TUI.Components.Interfaces;

namespace Client.TUI.Components.Containers.Interfaces;
public interface IConteinerComponent
{
    abstract void Add(BaseComponent component);
    abstract void Remove(BaseComponent component);
    abstract void Render();
    abstract Task WatchModifiedAsync(Queue<IBaseComponent> queue);
    abstract void WatchModified(Queue<IBaseComponent> queue);
}
