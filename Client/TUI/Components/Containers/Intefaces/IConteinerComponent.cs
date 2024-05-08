using Client.TUI.Components.Interfaces;

namespace Client.TUI.Components.Containers.Interfaces;
public interface IConteinerComponent
{
    abstract void Add(BaseComponent component);
    abstract void Remove(BaseComponent component);
    abstract void Render();
    abstract Task WatchModifiedAsync(Queue<IBaseComponentRender> queue);
    abstract void WatchModified(Queue<IBaseComponentRender> queue);
}
